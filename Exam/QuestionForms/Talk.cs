using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeakNamespace
{
    public class Talk
    {    
        public Talk(string text, short question)
        {
            TalkingForm tf = new TalkingForm(text, question);           
            tf.Show();           
        }
    }
    public partial class TalkingForm : Form
    {
        public TalkingForm(string text, short question)
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Load += new System.EventHandler(this.TalkingForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TalkingForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TalkingForm_KeyDown);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 66);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Speaker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = $"Lektor - pytanie: {question}";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.text = text;
            // button
            this.button1.Location = new System.Drawing.Point(10, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TalkingForm_KeyDown);
            // button
            this.button2.Location = new System.Drawing.Point(104, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Zatrzymaj";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TalkingForm_KeyDown);
            // button
            this.button3.Location = new System.Drawing.Point(197, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Wznów";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TalkingForm_KeyDown);
            //
            synt = new SpeechSynthesizer();
            var voices = synt.GetInstalledVoices(new CultureInfo("en-US"));
            if (voices.Count > 0)
                synt.SelectVoice(voices.First().VoiceInfo.Name);
            synt.Volume = 100;  // 0...100
            synt.Rate = 0;     // -10...10
        }
        string text = "";
        SpeechSynthesizer synt;
        private void TalkingForm_Load(object sender, EventArgs e)
        {
            talk(text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            talk(text);
            button1.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            synt.Pause();
            button2.Enabled = true;
            button3.Focus();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            synt.Resume();
            button3.Enabled = true;
        }
        void talk(string text)
        {
            button1.Enabled = false;
            try
            {
                synt.SpeakAsync(text);
                button1.Enabled = true;
            }
            catch (Exception exc)
            {
                try
                {
                    synt.SpeakAsync("Sorry, there was an error.");
                    button1.Enabled = true;
                }
                catch
                {
                    button1.Enabled = true;
                }
            }
        }
        private void TalkingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                synt.SpeakAsyncCancelAll();
                synt.Dispose();
            }
            catch { }

        }
        private void TalkingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button3;
    }
}
