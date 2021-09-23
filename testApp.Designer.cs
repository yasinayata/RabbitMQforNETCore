﻿
namespace RabbitMQforNETCore
{
    partial class testApp
    {
        ///<summary>
        /// Required designer variable.
        ///</summary>
        private System.ComponentModel.IContainer components = null;

        ///<summary>
        /// Clean up any resources being used.
        ///</summary>
        ///<param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        ///<summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        ///</summary>
        private void InitializeComponent()
        {
            this.cmbProvider = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textUserName = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textHostName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textExchange = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textQueueName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textRoutingKey = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textMessage = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textResult = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.cmbDirection = new System.Windows.Forms.ComboBox();
            this.btnGetMessage = new System.Windows.Forms.Button();
            this.textMessageArrived = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            //cmbProvider
            //
            this.cmbProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvider.FormattingEnabled = true;
            this.cmbProvider.Location = new System.Drawing.Point(238, 41);
            this.cmbProvider.Name = "cmbProvider";
            this.cmbProvider.Size = new System.Drawing.Size(292, 23);
            this.cmbProvider.TabIndex = 0;
            this.cmbProvider.SelectedIndexChanged += new System.EventHandler(this.CmbProvider_SelectedIndexChanged);
            //
            //label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "UserName";
            //
            //textUserName
            //
            this.textUserName.Location = new System.Drawing.Point(86, 12);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(146, 23);
            this.textUserName.TabIndex = 2;
            this.textUserName.Text = "guest";
            //
            //textPassword
            //
            this.textPassword.Location = new System.Drawing.Point(86, 41);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(146, 23);
            this.textPassword.TabIndex = 4;
            this.textPassword.Text = "guest";
            //
            //label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            //
            //textHostName
            //
            this.textHostName.Location = new System.Drawing.Point(86, 70);
            this.textHostName.Name = "textHostName";
            this.textHostName.Size = new System.Drawing.Size(146, 23);
            this.textHostName.TabIndex = 6;
            this.textHostName.Text = "localhost";
            //
            //label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Hostname";
            //
            //textExchange
            //
            this.textExchange.Location = new System.Drawing.Point(86, 99);
            this.textExchange.Name = "textExchange";
            this.textExchange.Size = new System.Drawing.Size(146, 23);
            this.textExchange.TabIndex = 8;
            this.textExchange.Text = "direct.numbers.exchange";
            //
            //label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Exchange";
            //
            //textQueueName
            //
            this.textQueueName.Location = new System.Drawing.Point(86, 157);
            this.textQueueName.Name = "textQueueName";
            this.textQueueName.Size = new System.Drawing.Size(146, 23);
            this.textQueueName.TabIndex = 12;
            this.textQueueName.Text = "demo-queue";
            //
            //label5
            //
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "QueueName";
            //
            //textRoutingKey
            //
            this.textRoutingKey.Location = new System.Drawing.Point(86, 128);
            this.textRoutingKey.Name = "textRoutingKey";
            this.textRoutingKey.Size = new System.Drawing.Size(146, 23);
            this.textRoutingKey.TabIndex = 10;
            this.textRoutingKey.Text = "odd.numbers";
            //
            //label6
            //
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "RoutingKey";
            //
            //textMessage
            //
            this.textMessage.Location = new System.Drawing.Point(86, 186);
            this.textMessage.Multiline = true;
            this.textMessage.Name = "textMessage";
            this.textMessage.Size = new System.Drawing.Size(444, 84);
            this.textMessage.TabIndex = 14;
            this.textMessage.Text = "Hello RabbitMQ";
            //
            //lblMessage
            //
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(7, 189);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(53, 15);
            this.lblMessage.TabIndex = 13;
            this.lblMessage.Text = "Message";
            //
            //label8
            //
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 279);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "Result";
            //
            //textResult
            //
            this.textResult.Location = new System.Drawing.Point(86, 276);
            this.textResult.Multiline = true;
            this.textResult.Name = "textResult";
            this.textResult.Size = new System.Drawing.Size(444, 52);
            this.textResult.TabIndex = 16;
            //
            //btnConnect
            //
            this.btnConnect.Location = new System.Drawing.Point(238, 73);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(143, 25);
            this.btnConnect.TabIndex = 17;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            //
            //btnSendMessage
            //
            this.btnSendMessage.Location = new System.Drawing.Point(387, 155);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(143, 25);
            this.btnSendMessage.TabIndex = 18;
            this.btnSendMessage.Text = "Send Message";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.BtnSendMessage_Click);
            //
            //cmbDirection
            //
            this.cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirection.FormattingEnabled = true;
            this.cmbDirection.Location = new System.Drawing.Point(238, 12);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(292, 23);
            this.cmbDirection.TabIndex = 0;
            this.cmbDirection.SelectedIndexChanged += new System.EventHandler(this.CmbDirection_SelectedIndexChanged);
            //
            //btnGetMessage
            //
            this.btnGetMessage.Location = new System.Drawing.Point(238, 155);
            this.btnGetMessage.Name = "btnGetMessage";
            this.btnGetMessage.Size = new System.Drawing.Size(143, 25);
            this.btnGetMessage.TabIndex = 19;
            this.btnGetMessage.Text = "Get Message";
            this.btnGetMessage.UseVisualStyleBackColor = true;
            this.btnGetMessage.Click += new System.EventHandler(this.BtnGetMessage_Click);
            //
            //textMessageArrived
            //
            this.textMessageArrived.Location = new System.Drawing.Point(86, 186);
            this.textMessageArrived.Multiline = true;
            this.textMessageArrived.Name = "textMessageArrived";
            this.textMessageArrived.Size = new System.Drawing.Size(444, 71);
            this.textMessageArrived.TabIndex = 21;
            //
            //testApp
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 334);
            this.Controls.Add(this.textMessageArrived);
            this.Controls.Add(this.btnGetMessage);
            this.Controls.Add(this.cmbDirection);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.textResult);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textMessage);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.textRoutingKey);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textQueueName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textExchange);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textHostName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textUserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProvider);
            this.Name = "testApp";
            this.Text = "RabbitMQ test application";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProvider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textUserName;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textHostName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textExchange;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textQueueName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textRoutingKey;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textResult;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.ComboBox cmbDirection;
        private System.Windows.Forms.Button btnGetMessage;
        private System.Windows.Forms.TextBox textMessageArrived;
    }
}

