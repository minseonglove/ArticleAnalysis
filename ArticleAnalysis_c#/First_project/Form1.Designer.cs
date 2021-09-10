namespace First_project
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Lab04 = new System.Windows.Forms.Label();
            this.Tb_URL = new System.Windows.Forms.TextBox();
            this.Lab_URL = new System.Windows.Forms.Label();
            this.Btn_Analysis = new System.Windows.Forms.Button();
            this.Lab01 = new System.Windows.Forms.Label();
            this.Lab07 = new System.Windows.Forms.Label();
            this.Lab08 = new System.Windows.Forms.Label();
            this.Lab09 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Lab13 = new System.Windows.Forms.Label();
            this.Lab12 = new System.Windows.Forms.Label();
            this.Lab11 = new System.Windows.Forms.Label();
            this.Lab10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Lab03 = new System.Windows.Forms.Label();
            this.Lab02 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lab04
            // 
            this.Lab04.AutoSize = true;
            this.Lab04.Location = new System.Drawing.Point(101, 230);
            this.Lab04.Name = "Lab04";
            this.Lab04.Size = new System.Drawing.Size(38, 12);
            this.Lab04.TabIndex = 4;
            this.Lab04.Text = "label1";
            // 
            // Tb_URL
            // 
            this.Tb_URL.Location = new System.Drawing.Point(47, 82);
            this.Tb_URL.Name = "Tb_URL";
            this.Tb_URL.Size = new System.Drawing.Size(495, 21);
            this.Tb_URL.TabIndex = 6;
            // 
            // Lab_URL
            // 
            this.Lab_URL.AutoSize = true;
            this.Lab_URL.Location = new System.Drawing.Point(45, 67);
            this.Lab_URL.Name = "Lab_URL";
            this.Lab_URL.Size = new System.Drawing.Size(90, 12);
            this.Lab_URL.TabIndex = 7;
            this.Lab_URL.Text = "기사 링크(URL)";
            // 
            // Btn_Analysis
            // 
            this.Btn_Analysis.Location = new System.Drawing.Point(555, 82);
            this.Btn_Analysis.Name = "Btn_Analysis";
            this.Btn_Analysis.Size = new System.Drawing.Size(75, 23);
            this.Btn_Analysis.TabIndex = 8;
            this.Btn_Analysis.Text = "분석";
            this.Btn_Analysis.UseVisualStyleBackColor = true;
            this.Btn_Analysis.Click += new System.EventHandler(this.Btn_Analysis_Click);
            // 
            // Lab01
            // 
            this.Lab01.AutoSize = true;
            this.Lab01.Location = new System.Drawing.Point(0, 0);
            this.Lab01.Name = "Lab01";
            this.Lab01.Size = new System.Drawing.Size(38, 12);
            this.Lab01.TabIndex = 14;
            this.Lab01.Text = "label1";
            // 
            // Lab07
            // 
            this.Lab07.AutoSize = true;
            this.Lab07.Location = new System.Drawing.Point(101, 265);
            this.Lab07.Name = "Lab07";
            this.Lab07.Size = new System.Drawing.Size(35, 12);
            this.Lab07.TabIndex = 23;
            this.Lab07.Text = "None";
            // 
            // Lab08
            // 
            this.Lab08.AutoSize = true;
            this.Lab08.Location = new System.Drawing.Point(101, 305);
            this.Lab08.Name = "Lab08";
            this.Lab08.Size = new System.Drawing.Size(35, 12);
            this.Lab08.TabIndex = 24;
            this.Lab08.Text = "None";
            // 
            // Lab09
            // 
            this.Lab09.AutoSize = true;
            this.Lab09.Location = new System.Drawing.Point(101, 345);
            this.Lab09.Name = "Lab09";
            this.Lab09.Size = new System.Drawing.Size(35, 12);
            this.Lab09.TabIndex = 25;
            this.Lab09.Text = "None";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "당일 : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 305);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "5거래일 :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 345);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 12);
            this.label9.TabIndex = 28;
            this.label9.Text = "20거래일 :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(45, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 29;
            this.label10.Text = "종목명 : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(292, 230);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 37;
            this.label11.Text = "마켓 : ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(272, 345);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 12);
            this.label12.TabIndex = 36;
            this.label12.Text = "20거래일 :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(278, 305);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 12);
            this.label13.TabIndex = 35;
            this.label13.Text = "5거래일 :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(295, 265);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 34;
            this.label14.Text = "당일 : ";
            // 
            // Lab13
            // 
            this.Lab13.AutoSize = true;
            this.Lab13.Location = new System.Drawing.Point(339, 345);
            this.Lab13.Name = "Lab13";
            this.Lab13.Size = new System.Drawing.Size(35, 12);
            this.Lab13.TabIndex = 33;
            this.Lab13.Text = "None";
            // 
            // Lab12
            // 
            this.Lab12.AutoSize = true;
            this.Lab12.Location = new System.Drawing.Point(339, 305);
            this.Lab12.Name = "Lab12";
            this.Lab12.Size = new System.Drawing.Size(35, 12);
            this.Lab12.TabIndex = 32;
            this.Lab12.Text = "None";
            // 
            // Lab11
            // 
            this.Lab11.AutoSize = true;
            this.Lab11.Location = new System.Drawing.Point(339, 265);
            this.Lab11.Name = "Lab11";
            this.Lab11.Size = new System.Drawing.Size(35, 12);
            this.Lab11.TabIndex = 31;
            this.Lab11.Text = "None";
            // 
            // Lab10
            // 
            this.Lab10.AutoSize = true;
            this.Lab10.Location = new System.Drawing.Point(339, 230);
            this.Lab10.Name = "Lab10";
            this.Lab10.Size = new System.Drawing.Size(38, 12);
            this.Lab10.TabIndex = 30;
            this.Lab10.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 38;
            this.label1.Text = "제목 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 39;
            this.label2.Text = "시간 : ";
            // 
            // Lab03
            // 
            this.Lab03.AutoSize = true;
            this.Lab03.Location = new System.Drawing.Point(100, 155);
            this.Lab03.Name = "Lab03";
            this.Lab03.Size = new System.Drawing.Size(35, 12);
            this.Lab03.TabIndex = 40;
            this.Lab03.Text = "None";
            // 
            // Lab02
            // 
            this.Lab02.AutoSize = true;
            this.Lab02.Location = new System.Drawing.Point(100, 121);
            this.Lab02.Name = "Lab02";
            this.Lab02.Size = new System.Drawing.Size(35, 12);
            this.Lab02.TabIndex = 41;
            this.Lab02.Text = "None";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 388);
            this.Controls.Add(this.Lab02);
            this.Controls.Add(this.Lab03);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.Lab13);
            this.Controls.Add(this.Lab12);
            this.Controls.Add(this.Lab11);
            this.Controls.Add(this.Lab10);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Lab09);
            this.Controls.Add(this.Lab08);
            this.Controls.Add(this.Lab07);
            this.Controls.Add(this.Lab01);
            this.Controls.Add(this.Btn_Analysis);
            this.Controls.Add(this.Lab_URL);
            this.Controls.Add(this.Tb_URL);
            this.Controls.Add(this.Lab04);
            this.Name = "Form1";
            this.Text = "Article_analysis";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Lab04;
        private System.Windows.Forms.TextBox Tb_URL;
        private System.Windows.Forms.Label Lab_URL;
        private System.Windows.Forms.Button Btn_Analysis;
        private System.Windows.Forms.Label Lab01;
        private System.Windows.Forms.Label Lab07;
        private System.Windows.Forms.Label Lab08;
        private System.Windows.Forms.Label Lab09;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label Lab13;
        private System.Windows.Forms.Label Lab12;
        private System.Windows.Forms.Label Lab11;
        private System.Windows.Forms.Label Lab10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Lab03;
        private System.Windows.Forms.Label Lab02;
    }
}

