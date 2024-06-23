using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiplomAE
{
    public partial class ChatUserControl : UserControl
    {
        public ChatUserControl()
        {
            InitializeComponent();
        }
        public string Sender
        {
            get => FIO.Text;
            set => FIO.Text = value;
        }
        public string Message
        {
            get => Text.Text;
            set => Text.Text = value;
        }
        public string SendDate
        {
            get => Date.Text;
            set => Date.Text = value;
        }
        public string Status
        {
            get => Statuss.Text;
            set => Statuss.Text = value;
        }
        public Image ProfileImage
        {
            get => Avatar.BackgroundImage;
            set => Avatar.BackgroundImage = value;
        }
    }
}
