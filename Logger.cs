using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ImageComparer
{
    public sealed class Logger : TextBox
    {
        private IContainer components;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            components = new Container();
        }


        private StringBuilder _builder = new StringBuilder();
        private bool topmost = true;
        //TODO add logfile

        public delegate void LoggerEvent(string text);

        [Category("Action"), Description("Distribute new messages to other handlers."), Browsable(true)]
        public event LoggerEvent NewText;

        [Category("Appearance"), Description("Enable current date to be displayed before incomming message in logger.")]
        public bool DateStamp { get; set; }

        private string dateStampFormat = "yyyy-MM-dd";

        [Category("Appearance"), Description("Set the DateStamp format.")]
        public string DateStampFormat { get { return dateStampFormat; } set { dateStampFormat = value; } }


        [Category("Appearance"), Description("Enable current Time to be displayed before incomming message in logger.")]
        public bool TimeStamp { get; set; }

        private string timeStampFormat = "HH-mm-ss";

        [Category("Appearance"), Description("Set the TimeStamp format.")]
        public string TimeStampFormat { get { return timeStampFormat; } set { timeStampFormat = value; } }

        [Category("Appearance"), Description("Enable message Count to be displayed before incomming message in logger.")]
        public bool CountStamp { get; set; }

        private string countStampFormat = "D4";
        [Category("Appearance"), Description("Set the Count format.")]
        public string CountStampFormat { get { return countStampFormat; } set { countStampFormat = value; } }

        [Category("Appearance"), Description("Current message counter of the loggger.")]
        public int Count { get; set; }

        public Logger()
        {
            InitializeComponent();
            Multiline = true;
            Font = new Font("Lucida Console", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ScrollBars = ScrollBars.Both;
            ReadOnly = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public new void Clear()
        {
            clear(0);
        }

        public void Clear(bool ResetLineCount)
        {
            clear(ResetLineCount ? 0 : Count);
        }
        private void clear(int CountValue)
        {
            topmost = true;
            Count = CountValue;
            _builder.Clear();
            base.Clear();
        }

        public void AddLine(string text)
        {
            if (!topmost)
            {
                _builder.AppendLine();
            }
            appendStamps();
            _builder.Append(text);
            Text = _builder.ToString();
            SelectionStart = TextLength;
            ScrollToCaret();
            topmost = false;
            if (NewText != null) NewText(text);
        }

        private void appendStamps()
        {
            if (CountStamp)
            {
                _builder.Append(Count.ToString(countStampFormat));
                _builder.Append(' ');
                Count++;
            }
            if (DateStamp | TimeStamp)
            {
                var now = DateTime.Now;
                if (DateStamp)
                {
                    _builder.Append(now.ToString(dateStampFormat));
                    _builder.Append(' ');
                }
                if (TimeStamp)
                {
                    _builder.Append(now.ToString(timeStampFormat));
                    _builder.Append(' ');
                }
            }

        }

    }
}
