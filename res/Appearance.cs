using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register
{
    public class Appearance
    {
        public static MetroThemeStyle Theme { get; set; } = MetroThemeStyle.Dark;
        public static MetroColorStyle Style { get; set; } = MetroColorStyle.Purple;
        public static Color TextColor { get; set; } = Color.White;
        public static Font ChatFont { get; set; } = new Font("Arial", 15, FontStyle.Regular);
        public static Font BoldFont { get; set; } = new Font("Arial", 10, FontStyle.Bold);
        public static Font RegularFont { get; set; } = new Font("Arial", 10, FontStyle.Regular);
        public static Font CursiveFont { get; set; } = new Font("Arial", 10, FontStyle.Italic);
        public static Font UnderlineFont { get; set; } = new Font("Arial", 10, FontStyle.Underline);

        public static void CustomizeForm(MetroForm form) {
            form.AutoScaleMode = AutoScaleMode.None;
            foreach (Control control in form.Controls) {
                control.Font = RegularFont;
                if (control is TextBox) {
                    var textbox = control as TextBox;
                    textbox.Font = ChatFont;
                }
                if (control is Label) {
                    Label label = control as Label;
                    label.ForeColor = TextColor;
                    label.Font = BoldFont;
                }
                if(control is CheckBox) {
                    var checkBox = control as CheckBox;
                    checkBox.ForeColor = TextColor;
                }
                if(control is TrackBar)
                {
                    var trackbar = control as TrackBar;
                    if (Theme == MetroThemeStyle.Dark) trackbar.BackColor = Color.Black;
                    else trackbar.BackColor = Color.White;
                }
            }
            form.BorderStyle = MetroFormBorderStyle.FixedSingle;
            form.Resizable = false;
            form.ControlBox = false;

            form.Theme = Theme;
            form.Style = Style;
        }

    }
}
