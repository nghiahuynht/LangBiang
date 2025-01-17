namespace AutoQRDoor
{
    partial class Form1
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnectDevice = new System.Windows.Forms.Button();
            this.dataGridView_IPDevice = new System.Windows.Forms.DataGridView();
            this.lblStatusConntion = new System.Windows.Forms.Label();
            this.btnDisConnect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_IPDevice)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(21, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách thiết bị";
            // 
            // btnConnectDevice
            // 
            this.btnConnectDevice.Location = new System.Drawing.Point(25, 240);
            this.btnConnectDevice.Name = "btnConnectDevice";
            this.btnConnectDevice.Size = new System.Drawing.Size(120, 23);
            this.btnConnectDevice.TabIndex = 2;
            this.btnConnectDevice.Text = "Kết nối";
            this.btnConnectDevice.UseVisualStyleBackColor = true;
            this.btnConnectDevice.Click += new System.EventHandler(this.btnConnectDevice_Click);
            // 
            // dataGridView_IPDevice
            // 
            this.dataGridView_IPDevice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_IPDevice.Location = new System.Drawing.Point(25, 65);
            this.dataGridView_IPDevice.Name = "dataGridView_IPDevice";
            this.dataGridView_IPDevice.RowTemplate.Height = 24;
            this.dataGridView_IPDevice.Size = new System.Drawing.Size(835, 150);
            this.dataGridView_IPDevice.TabIndex = 4;
            // 
            // lblStatusConntion
            // 
            this.lblStatusConntion.AutoSize = true;
            this.lblStatusConntion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusConntion.Location = new System.Drawing.Point(605, 240);
            this.lblStatusConntion.Name = "lblStatusConntion";
            this.lblStatusConntion.Size = new System.Drawing.Size(139, 20);
            this.lblStatusConntion.TabIndex = 5;
            this.lblStatusConntion.Text = "Đang ngắt kết nối";
            // 
            // btnDisConnect
            // 
            this.btnDisConnect.Location = new System.Drawing.Point(182, 240);
            this.btnDisConnect.Name = "btnDisConnect";
            this.btnDisConnect.Size = new System.Drawing.Size(122, 23);
            this.btnDisConnect.TabIndex = 6;
            this.btnDisConnect.Text = "Ngắt kết nối";
            this.btnDisConnect.UseVisualStyleBackColor = true;
            this.btnDisConnect.Click += new System.EventHandler(this.btnDisConnect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 284);
            this.Controls.Add(this.btnDisConnect);
            this.Controls.Add(this.lblStatusConntion);
            this.Controls.Add(this.dataGridView_IPDevice);
            this.Controls.Add(this.btnConnectDevice);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "GAMAN - Phần mềm soát vé";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_IPDevice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnectDevice;
        private System.Windows.Forms.DataGridView dataGridView_IPDevice;
        private System.Windows.Forms.Label lblStatusConntion;
        private System.Windows.Forms.Button btnDisConnect;
    }
}

