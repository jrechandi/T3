using System.Windows.Forms;

namespace T3.Clases
{
    class _Cls_ExtensionWebBrowser : WebBrowser
    {
        public const int WM_PARENTNOTIFY = 0x0210;
        public const int WM_DESTROY = 2;

        public delegate void ClosingEventHandler();
        public event ClosingEventHandler Closing;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_PARENTNOTIFY:
                    if (!this.DesignMode)
                    {
                        if (m.WParam.ToInt32() == WM_DESTROY)
                        {
                            if (this.Closing != null)
                            {
                                this.Closing();
                            }
                        }
                    }
                    base.DefWndProc(ref m);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
}
