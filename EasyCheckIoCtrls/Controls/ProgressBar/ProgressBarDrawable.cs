using static System.Net.Mime.MediaTypeNames;

namespace EasyCheckIoCtrls.Controls
{
	public class ProgressBarDrawable : IDrawable
	{
		public Paint StrokePaint { get; set; }
		public Paint ProgressPaint { get; set; }

		public double Progress { get; set; }
        public double MaximumValue { get; set; }
        public double MinimumValue { get; set; }
        public CornerRadius CornerRadius { get; set; } = 6f;
		public ProgressBarStyle Style { get; set; }
		public bool IsAnimating { get; set; }
		public bool IsVertical { get; set; }

		public void Draw(ICanvas canvas, RectF dirtyRect)
		{
			canvas.Antialias = true;

			DrawTrack(canvas, dirtyRect);

			DrawProgress(canvas, dirtyRect);
			DrawText(canvas, dirtyRect);
		}

		public virtual void DrawTrack(ICanvas canvas, RectF dirtyRect)
		{
			canvas.SaveState();

			canvas.SetFillPaint(StrokePaint, dirtyRect);

			if (Style == ProgressBarStyle.Square)
				canvas.FillRectangle(dirtyRect);
			else
				canvas.FillRoundedRectangle(dirtyRect,
					CornerRadius.TopLeft,
					CornerRadius.TopRight,
					CornerRadius.BottomLeft,
					CornerRadius.BottomRight);

			canvas.RestoreState();
		}

		public virtual void DrawProgress(ICanvas canvas, RectF dirtyRect)
		{
			canvas.SaveState();

			RectF rect;

		   var Result = (1.0 - 0) / (MaximumValue - MinimumValue) * (Progress-MinimumValue)+0;



			if (IsVertical)
			{
				var progressHeight = dirtyRect.Height * Result;
				var progressY = dirtyRect.Y + dirtyRect.Height - progressHeight;

				rect = new Rect(
					dirtyRect.X,
					progressY,
					dirtyRect.Width,
					progressHeight);
			}
			else
			{
				rect = new Rect(
					dirtyRect.X,
					dirtyRect.Y,
					dirtyRect.Width * Result,
					dirtyRect.Height);
			}

			canvas.SetFillPaint(ProgressPaint, dirtyRect);

			if (Style == ProgressBarStyle.Square)
				canvas.FillRectangle(rect);
			else
				canvas.FillRoundedRectangle(rect,
				CornerRadius.TopLeft,
				CornerRadius.TopRight,
				CornerRadius.BottomLeft,
				CornerRadius.BottomRight);

			canvas.RestoreState();
		}

        public virtual void DrawText(ICanvas canvas, RectF dirtyRect)
        {
            canvas.SaveState();



            var x = 0;
            var y = 0;
            var width = dirtyRect.Width;
            var height = dirtyRect.Height;


            var horizontalAlignment = HorizontalAlignment.Center;

                    horizontalAlignment = HorizontalAlignment.Center;

            var verticalAlignment = VerticalAlignment.Center;


                    verticalAlignment = VerticalAlignment.Center;


            canvas.DrawString(Progress.ToString(), x, y, width, height, horizontalAlignment, verticalAlignment);

            canvas.RestoreState();
        }
    }
}