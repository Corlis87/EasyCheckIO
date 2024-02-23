using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using Sharp7;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Program.Events;
using TiaFrameworkCore.Shared._03_DataBlock;
using TiaFrameworkCore.Shared._06_Enum;
using TiaFrameworkCore.Shared._11_Contracts;
using TiaFrameworkCore.Shared._22_Services;
using TiaFrameworkCore.Siemens._03_DataBlock;
using TiaFrameworkCore.Siemens._13_Helper;
using TiaFrameworkCore.ViewModel;

namespace TiaFrameworkCore.Siemens._30_Lgc
{
    public class S7Lgc : IS7Lgc
    {
        #region Fields

        private readonly IS7Com _S7Com;
        private readonly IFileSaver _FileSaver;

        #endregion

        #region Properties
        public S7Param Param { get; set; }
        public S7ViewValue ViewValue { get; }
        public S7DB DB { get; set; }

        #endregion

        #region ctr
        public S7Lgc(IS7Com s7Com, IFileSaver filesaver)
        {
            DB = new S7DB();
            Param = new S7Param();
            ViewValue = new();
            _S7Com = s7Com;
            _S7Com.TagsChanged += TagsChangedEvent;
            _FileSaver= filesaver;
        }
        #endregion

        #region Method

        #region Connect
        public OperationResult Connect(S7NetConfig s7HwConfig)
        {
            return _S7Com.Connect(s7HwConfig);
        }

        #endregion

        #region Disconnect
        public OperationResult Disconnect()
        {
            return _S7Com.Disconnect();
        }

        #endregion

        #region CompileS7Var
        public OperationResult CompileS7Tags()
        {
            DB.Tags.Clear();
            foreach (var item in Param.Tags)
            {
                S7Helper.CreateTag(item);
                DB.Tags.Add(item);
            }
            RefreshTagsView();
            _S7Com.CalculateBuffer(DB.Tags);
            return new OperationResult(0, "Compile Success", true);          

        }

        public OperationResult CompileS7Tags(List<S7Tag> s7Tags)
        {
            DB.Tags.Clear();
            foreach (var item in s7Tags)
            {
                S7Helper.CreateTag(item);
                DB.Tags.Add(item);
            }
            RefreshTagsView();
            _S7Com.CalculateBuffer(DB.Tags);
            return new OperationResult(0, "Compile Success", true);

        }

        #endregion

        #region RefreshTagsValue
        public void RefreshTagsView()
        {
            IEnumerable<S7Tag> taglist = DB.Tags;
            ViewValue.Tags.Clear();
            foreach (var item in taglist)
            {
                ViewValue.Tags.Add(new t_S7TagViewModel(Shell.Current.Handler.MauiContext.Services.GetService<ICoreServices>(), item));
            }
        }
        public void RefreshTagsView(IEnumerable<S7Tag> taglist)
        {
            ViewValue.Tags.Clear();
            foreach (var item in taglist)
            {
                ViewValue.Tags.Add(new t_S7TagViewModel(Shell.Current.Handler.MauiContext.Services.GetService<ICoreServices>(), item));
            }
        }
        #endregion

        #endregion

        #region Event

        #region TagsChangedEvent
        private void TagsChangedEvent()
        {
            _S7Com.CreateContentFromVariableList(DB.Tags);
          
            if (DB.Tags != null && DB.Tags.Count > 0)
                for (int i = 0; i < DB.Tags.Count; i++)
                {
                    ViewValue.Tags[i].Content = DB.Tags[i].Content;
                    ViewValue.Tags[i].Scaling();
                }
        }
        #endregion

        #endregion
    }
}