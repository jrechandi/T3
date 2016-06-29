namespace T3
{
    partial class Frm_WaitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._Lbl_WaitMsg = new System.Windows.Forms.Label();
            this._Prg_Wait = new System.Windows.Forms.ProgressBar();
            this._Tim_Timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // _Lbl_WaitMsg
            // 
            this._Lbl_WaitMsg.AutoSize = true;
            this._Lbl_WaitMsg.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_WaitMsg.Location = new System.Drawing.Point(9, 5);
            this._Lbl_WaitMsg.Name = "_Lbl_WaitMsg";
            this._Lbl_WaitMsg.Size = new System.Drawing.Size(216, 13);
            this._Lbl_WaitMsg.TabIndex = 0;
            this._Lbl_WaitMsg.Text = "Espere por favor, Cargando Datos...";
            // 
            // _Prg_Wait
            // 
            this._Prg_Wait.Location = new System.Drawing.Point(12, 21);
            this._Prg_Wait.Name = "_Prg_Wait";
            this._Prg_Wait.Size = new System.Drawing.Size(285, 23);
            this._Prg_Wait.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this._Prg_Wait.TabIndex = 1;
            // 
            // _Tim_Timer
            // 
            this._Tim_Timer.Tick += new System.EventHandler(this._Tim_Timer_Tick);
            // 
            // Frm_WaitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 53);
            this.ControlBox = false;
            this.Controls.Add(this._Prg_Wait);
            this.Controls.Add(this._Lbl_WaitMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_WaitForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label _Lbl_WaitMsg;
        private System.Windows.Forms.ProgressBar _Prg_Wait;
        private System.Windows.Forms.Timer _Tim_Timer;
    }
}