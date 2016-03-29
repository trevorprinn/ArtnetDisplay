using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtnetDisplay {

    class DataGridViewBarColumn : DataGridViewImageColumn {

        public DataGridViewBarColumn() {
            CellTemplate = new DataGridViewBarCell();
        }

        public override DataGridViewCell CellTemplate {
            get {
                return base.CellTemplate;
            }

            set {
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(DataGridViewBarCell))) {
                    throw new InvalidCastException("Must be a DataGridViewBarCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    class DataGridViewBarCell : DataGridViewImageCell {

        private static Image _emptyImage;
        static DataGridViewBarCell() {
            _emptyImage = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }

        public DataGridViewBarCell() {
            ValueType = typeof(int);
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts) {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

            int barValue = value == null ? 0 : Convert.ToInt32(value);
            double percent = barValue / 255d;

            graphics.FillRectangle(Brushes.Green, cellBounds.X + 2,
                cellBounds.Y + 2, Convert.ToInt32(percent * (cellBounds.Width - 2)),
                cellBounds.Height / 1 - 5);
        }

        public override object Clone() {
            return base.Clone() as DataGridViewBarCell;
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context) {
            return _emptyImage;
        }
    }
}
