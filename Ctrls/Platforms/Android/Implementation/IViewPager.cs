using System;
using Ctrls.Abstractions;

namespace Ctrls.Droid
{
    internal interface IViewPager
    {
        void SetPagingEnabled(bool enabled);
        void SetElement(CarouselViewControl element);
    }
}
