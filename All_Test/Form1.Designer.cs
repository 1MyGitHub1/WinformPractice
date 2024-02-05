
namespace All_Test
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_StandardCancel = new System.Windows.Forms.Button();
            this.btn_ReStandardCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btn_AcquisitionTime = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_age = new System.Windows.Forms.TextBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_read = new System.Windows.Forms.Button();
            this.btn_file = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lab_result = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btn_reflect = new System.Windows.Forms.Button();
            this.btn_reflectCreat = new System.Windows.Forms.Button();
            this.btn_reflectC = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "运行";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(7, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(788, 467);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(780, 441);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "测试页1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_StandardCancel);
            this.groupBox5.Controls.Add(this.btn_ReStandardCancel);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Location = new System.Drawing.Point(227, 172);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(249, 106);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Task操作";
            // 
            // btn_StandardCancel
            // 
            this.btn_StandardCancel.Location = new System.Drawing.Point(124, 69);
            this.btn_StandardCancel.Name = "btn_StandardCancel";
            this.btn_StandardCancel.Size = new System.Drawing.Size(66, 23);
            this.btn_StandardCancel.TabIndex = 0;
            this.btn_StandardCancel.Text = "标准取消";
            this.btn_StandardCancel.UseVisualStyleBackColor = true;
            this.btn_StandardCancel.Click += new System.EventHandler(this.btn_StandardCancel_Click);
            // 
            // btn_ReStandardCancel
            // 
            this.btn_ReStandardCancel.Location = new System.Drawing.Point(40, 69);
            this.btn_ReStandardCancel.Name = "btn_ReStandardCancel";
            this.btn_ReStandardCancel.Size = new System.Drawing.Size(66, 23);
            this.btn_ReStandardCancel.TabIndex = 0;
            this.btn_ReStandardCancel.Text = "非标准取消";
            this.btn_ReStandardCancel.UseVisualStyleBackColor = true;
            this.btn_ReStandardCancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "取消正在运行得Task：";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btn_AcquisitionTime);
            this.groupBox6.Location = new System.Drawing.Point(6, 228);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(206, 50);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "获取代码运行时间";
            // 
            // btn_AcquisitionTime
            // 
            this.btn_AcquisitionTime.Location = new System.Drawing.Point(75, 17);
            this.btn_AcquisitionTime.Name = "btn_AcquisitionTime";
            this.btn_AcquisitionTime.Size = new System.Drawing.Size(75, 23);
            this.btn_AcquisitionTime.TabIndex = 0;
            this.btn_AcquisitionTime.Text = "开始";
            this.btn_AcquisitionTime.UseVisualStyleBackColor = true;
            this.btn_AcquisitionTime.Click += new System.EventHandler(this.btn_AcquisitionTime_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_Start);
            this.groupBox4.Location = new System.Drawing.Point(6, 172);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(206, 50);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "随机获取";
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(75, 17);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 23);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "开始";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Location = new System.Drawing.Point(598, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(168, 148);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "实时读取";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(28, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 49);
            this.button2.TabIndex = 0;
            this.button2.Text = "运行即读取";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox_age);
            this.groupBox2.Controls.Add(this.textBox_name);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.btn_read);
            this.groupBox2.Controls.Add(this.btn_file);
            this.groupBox2.Location = new System.Drawing.Point(227, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 148);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "配置文件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(141, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "集数：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "名字：";
            // 
            // textBox_age
            // 
            this.textBox_age.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_age.Location = new System.Drawing.Point(196, 42);
            this.textBox_age.Multiline = true;
            this.textBox_age.Name = "textBox_age";
            this.textBox_age.Size = new System.Drawing.Size(66, 27);
            this.textBox_age.TabIndex = 2;
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_name.Location = new System.Drawing.Point(59, 42);
            this.textBox_name.Multiline = true;
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(66, 27);
            this.textBox_name.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(59, 99);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(151, 27);
            this.textBox1.TabIndex = 2;
            // 
            // btn_read
            // 
            this.btn_read.Location = new System.Drawing.Point(268, 89);
            this.btn_read.Name = "btn_read";
            this.btn_read.Size = new System.Drawing.Size(69, 44);
            this.btn_read.TabIndex = 1;
            this.btn_read.Text = "读取";
            this.btn_read.UseVisualStyleBackColor = true;
            this.btn_read.Click += new System.EventHandler(this.btn_read_Click);
            // 
            // btn_file
            // 
            this.btn_file.Location = new System.Drawing.Point(268, 29);
            this.btn_file.Name = "btn_file";
            this.btn_file.Size = new System.Drawing.Size(68, 44);
            this.btn_file.TabIndex = 0;
            this.btn_file.Text = "保存";
            this.btn_file.UseVisualStyleBackColor = true;
            this.btn_file.Click += new System.EventHandler(this.btn_file_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lab_result);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(6, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 148);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "int转byte[]";
            // 
            // lab_result
            // 
            this.lab_result.AutoSize = true;
            this.lab_result.Location = new System.Drawing.Point(33, 65);
            this.lab_result.Name = "lab_result";
            this.lab_result.Size = new System.Drawing.Size(65, 12);
            this.lab_result.TabIndex = 1;
            this.lab_result.Text = "lab_result";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(780, 441);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "测试页2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btn_reflectC);
            this.groupBox7.Controls.Add(this.btn_reflectCreat);
            this.groupBox7.Controls.Add(this.btn_reflect);
            this.groupBox7.Location = new System.Drawing.Point(495, 172);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(271, 106);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "反射";
            // 
            // btn_reflect
            // 
            this.btn_reflect.Location = new System.Drawing.Point(24, 27);
            this.btn_reflect.Name = "btn_reflect";
            this.btn_reflect.Size = new System.Drawing.Size(75, 23);
            this.btn_reflect.TabIndex = 0;
            this.btn_reflect.Text = "反射";
            this.btn_reflect.UseVisualStyleBackColor = true;
            this.btn_reflect.Click += new System.EventHandler(this.btn_reflect_Click);
            // 
            // btn_reflectCreat
            // 
            this.btn_reflectCreat.Location = new System.Drawing.Point(122, 27);
            this.btn_reflectCreat.Name = "btn_reflectCreat";
            this.btn_reflectCreat.Size = new System.Drawing.Size(107, 23);
            this.btn_reflectCreat.TabIndex = 1;
            this.btn_reflectCreat.Text = "反射创建方法";
            this.btn_reflectCreat.UseVisualStyleBackColor = true;
            this.btn_reflectCreat.Click += new System.EventHandler(this.btn_reflectCreat_Click);
            // 
            // btn_reflectC
            // 
            this.btn_reflectC.Location = new System.Drawing.Point(24, 69);
            this.btn_reflectC.Name = "btn_reflectC";
            this.btn_reflectC.Size = new System.Drawing.Size(75, 23);
            this.btn_reflectC.TabIndex = 2;
            this.btn_reflectC.Text = "反射程序集";
            this.btn_reflectC.UseVisualStyleBackColor = true;
            this.btn_reflectC.Click += new System.EventHandler(this.btn_reflectC_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 476);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_file;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_read;
        private System.Windows.Forms.TextBox textBox_age;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lab_result;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_ReStandardCancel;
        private System.Windows.Forms.Button btn_StandardCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btn_AcquisitionTime;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btn_reflect;
        private System.Windows.Forms.Button btn_reflectCreat;
        private System.Windows.Forms.Button btn_reflectC;
    }
}

