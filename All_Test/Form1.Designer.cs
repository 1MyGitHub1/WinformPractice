
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
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btn_modbus = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_floatValue = new System.Windows.Forms.TextBox();
            this.btn_shift = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btn_TimerTest = new System.Windows.Forms.Button();
            this.tb_min = new System.Windows.Forms.TextBox();
            this.tb_times = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_TimeStart = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btn_reflectC = new System.Windows.Forms.Button();
            this.btn_reflectCreat = new System.Windows.Forms.Button();
            this.btn_reflect = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_StandardCancel = new System.Windows.Forms.Button();
            this.btn_ReStandardCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btn_AcquisitionTime = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_age = new System.Windows.Forms.TextBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_read = new System.Windows.Forms.Button();
            this.btn_file = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_convert = new System.Windows.Forms.Button();
            this.lab_result = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.list_log = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
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
            this.tabPage1.Controls.Add(this.groupBox10);
            this.tabPage1.Controls.Add(this.groupBox9);
            this.tabPage1.Controls.Add(this.groupBox8);
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
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.button2);
            this.groupBox10.Location = new System.Drawing.Point(540, 296);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(226, 142);
            this.groupBox10.TabIndex = 8;
            this.groupBox10.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(136, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 37);
            this.button2.TabIndex = 0;
            this.button2.Text = "读取";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btn_modbus);
            this.groupBox9.Controls.Add(this.label6);
            this.groupBox9.Controls.Add(this.tb_floatValue);
            this.groupBox9.Controls.Add(this.btn_shift);
            this.groupBox9.Location = new System.Drawing.Point(316, 296);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(218, 142);
            this.groupBox9.TabIndex = 7;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "浮点数转4字节";
            // 
            // btn_modbus
            // 
            this.btn_modbus.Location = new System.Drawing.Point(117, 99);
            this.btn_modbus.Name = "btn_modbus";
            this.btn_modbus.Size = new System.Drawing.Size(79, 32);
            this.btn_modbus.TabIndex = 0;
            this.btn_modbus.Text = "modbus";
            this.btn_modbus.UseVisualStyleBackColor = true;
            this.btn_modbus.Click += new System.EventHandler(this.btn_modbus_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "Modbus协议返回解析";
            // 
            // tb_floatValue
            // 
            this.tb_floatValue.Location = new System.Drawing.Point(9, 30);
            this.tb_floatValue.Name = "tb_floatValue";
            this.tb_floatValue.Size = new System.Drawing.Size(74, 21);
            this.tb_floatValue.TabIndex = 1;
            this.tb_floatValue.Text = "90";
            // 
            // btn_shift
            // 
            this.btn_shift.Location = new System.Drawing.Point(117, 20);
            this.btn_shift.Name = "btn_shift";
            this.btn_shift.Size = new System.Drawing.Size(79, 31);
            this.btn_shift.TabIndex = 0;
            this.btn_shift.Text = "button3";
            this.btn_shift.UseVisualStyleBackColor = true;
            this.btn_shift.Click += new System.EventHandler(this.btn_shift_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btn_TimerTest);
            this.groupBox8.Controls.Add(this.tb_min);
            this.groupBox8.Controls.Add(this.tb_times);
            this.groupBox8.Controls.Add(this.label5);
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Controls.Add(this.btn_Stop);
            this.groupBox8.Controls.Add(this.btn_TimeStart);
            this.groupBox8.Location = new System.Drawing.Point(6, 296);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(289, 142);
            this.groupBox8.TabIndex = 6;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "延时/倒计时";
            // 
            // btn_TimerTest
            // 
            this.btn_TimerTest.Location = new System.Drawing.Point(201, 104);
            this.btn_TimerTest.Name = "btn_TimerTest";
            this.btn_TimerTest.Size = new System.Drawing.Size(75, 23);
            this.btn_TimerTest.TabIndex = 3;
            this.btn_TimerTest.Text = "延时";
            this.btn_TimerTest.UseVisualStyleBackColor = true;
            this.btn_TimerTest.Click += new System.EventHandler(this.btn_TimerTest_Click);
            // 
            // tb_min
            // 
            this.tb_min.Location = new System.Drawing.Point(119, 106);
            this.tb_min.Name = "tb_min";
            this.tb_min.Size = new System.Drawing.Size(74, 21);
            this.tb_min.TabIndex = 2;
            this.tb_min.Text = "1";
            // 
            // tb_times
            // 
            this.tb_times.Location = new System.Drawing.Point(13, 57);
            this.tb_times.Name = "tb_times";
            this.tb_times.Size = new System.Drawing.Size(100, 21);
            this.tb_times.TabIndex = 2;
            this.tb_times.Text = "1000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "定时器得实现：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "每隔一秒执行一次";
            // 
            // btn_TimeStart
            // 
            this.btn_TimeStart.Location = new System.Drawing.Point(119, 57);
            this.btn_TimeStart.Name = "btn_TimeStart";
            this.btn_TimeStart.Size = new System.Drawing.Size(75, 23);
            this.btn_TimeStart.TabIndex = 0;
            this.btn_TimeStart.Text = "开始";
            this.btn_TimeStart.UseVisualStyleBackColor = true;
            this.btn_TimeStart.Click += new System.EventHandler(this.btn_TimeStart_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btn_reflectC);
            this.groupBox7.Controls.Add(this.btn_reflectCreat);
            this.groupBox7.Controls.Add(this.btn_reflect);
            this.groupBox7.Location = new System.Drawing.Point(178, 172);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(148, 106);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "反射";
            // 
            // btn_reflectC
            // 
            this.btn_reflectC.Location = new System.Drawing.Point(24, 49);
            this.btn_reflectC.Name = "btn_reflectC";
            this.btn_reflectC.Size = new System.Drawing.Size(75, 23);
            this.btn_reflectC.TabIndex = 2;
            this.btn_reflectC.Text = "反射程序集";
            this.btn_reflectC.UseVisualStyleBackColor = true;
            this.btn_reflectC.Click += new System.EventHandler(this.btn_reflectC_Click);
            // 
            // btn_reflectCreat
            // 
            this.btn_reflectCreat.Location = new System.Drawing.Point(24, 78);
            this.btn_reflectCreat.Name = "btn_reflectCreat";
            this.btn_reflectCreat.Size = new System.Drawing.Size(107, 23);
            this.btn_reflectCreat.TabIndex = 1;
            this.btn_reflectCreat.Text = "反射创建方法";
            this.btn_reflectCreat.UseVisualStyleBackColor = true;
            this.btn_reflectCreat.Click += new System.EventHandler(this.btn_reflectCreat_Click);
            // 
            // btn_reflect
            // 
            this.btn_reflect.Location = new System.Drawing.Point(24, 20);
            this.btn_reflect.Name = "btn_reflect";
            this.btn_reflect.Size = new System.Drawing.Size(75, 23);
            this.btn_reflect.TabIndex = 0;
            this.btn_reflect.Text = "反射";
            this.btn_reflect.UseVisualStyleBackColor = true;
            this.btn_reflect.Click += new System.EventHandler(this.btn_reflect_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_StandardCancel);
            this.groupBox5.Controls.Add(this.btn_ReStandardCancel);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Location = new System.Drawing.Point(325, 18);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(209, 148);
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
            this.groupBox6.Size = new System.Drawing.Size(166, 50);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "获取代码运行时间";
            // 
            // btn_AcquisitionTime
            // 
            this.btn_AcquisitionTime.Location = new System.Drawing.Point(52, 20);
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
            this.groupBox4.Size = new System.Drawing.Size(166, 50);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "随机获取";
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(52, 18);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 23);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "开始";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.list_log);
            this.groupBox3.Location = new System.Drawing.Point(540, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(226, 260);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "控制台输出";
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
            this.groupBox2.Location = new System.Drawing.Point(6, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(311, 148);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "配置文件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "集数：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "名字：";
            // 
            // textBox_age
            // 
            this.textBox_age.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_age.Location = new System.Drawing.Point(61, 61);
            this.textBox_age.Multiline = true;
            this.textBox_age.Name = "textBox_age";
            this.textBox_age.Size = new System.Drawing.Size(66, 27);
            this.textBox_age.TabIndex = 2;
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_name.Location = new System.Drawing.Point(61, 24);
            this.textBox_name.Multiline = true;
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(66, 27);
            this.textBox_name.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(61, 100);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(151, 27);
            this.textBox1.TabIndex = 2;
            // 
            // btn_read
            // 
            this.btn_read.Location = new System.Drawing.Point(221, 89);
            this.btn_read.Name = "btn_read";
            this.btn_read.Size = new System.Drawing.Size(69, 44);
            this.btn_read.TabIndex = 1;
            this.btn_read.Text = "读取";
            this.btn_read.UseVisualStyleBackColor = true;
            this.btn_read.Click += new System.EventHandler(this.btn_read_Click);
            // 
            // btn_file
            // 
            this.btn_file.Location = new System.Drawing.Point(221, 29);
            this.btn_file.Name = "btn_file";
            this.btn_file.Size = new System.Drawing.Size(68, 44);
            this.btn_file.TabIndex = 0;
            this.btn_file.Text = "保存";
            this.btn_file.UseVisualStyleBackColor = true;
            this.btn_file.Click += new System.EventHandler(this.btn_file_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_convert);
            this.groupBox1.Controls.Add(this.lab_result);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(334, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 106);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "int转byte[]";
            // 
            // btn_convert
            // 
            this.btn_convert.Location = new System.Drawing.Point(103, 56);
            this.btn_convert.Name = "btn_convert";
            this.btn_convert.Size = new System.Drawing.Size(75, 34);
            this.btn_convert.TabIndex = 2;
            this.btn_convert.Text = "button3";
            this.btn_convert.UseVisualStyleBackColor = true;
            this.btn_convert.Click += new System.EventHandler(this.btn_convert_Click);
            // 
            // lab_result
            // 
            this.lab_result.AutoSize = true;
            this.lab_result.Location = new System.Drawing.Point(16, 29);
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
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(201, 57);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(75, 23);
            this.btn_Stop.TabIndex = 0;
            this.btn_Stop.Text = "停止";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // list_log
            // 
            this.list_log.BackColor = System.Drawing.SystemColors.WindowText;
            this.list_log.ForeColor = System.Drawing.SystemColors.Window;
            this.list_log.Location = new System.Drawing.Point(6, 20);
            this.list_log.Name = "list_log";
            this.list_log.ReadOnly = true;
            this.list_log.Size = new System.Drawing.Size(214, 235);
            this.list_log.TabIndex = 1;
            this.list_log.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 476);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btn_convert;
        private System.Windows.Forms.TextBox tb_times;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_TimeStart;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox tb_floatValue;
        private System.Windows.Forms.Button btn_shift;
        private System.Windows.Forms.Button btn_TimerTest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button btn_modbus;
        private System.Windows.Forms.TextBox tb_min;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.RichTextBox list_log;
    }
}

