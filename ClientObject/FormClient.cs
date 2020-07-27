using LibClientServer;
using LibRemotingObj;
using System;

using System.Windows.Forms;

namespace ClientObject
{
    public partial class FormClient : Form, IClientObserver
    {
        ModelRemoteObject mModelRemoteObject;

        public void Invoke(object obj)
        {
            if (obj is string)
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        //string msg = (string)obj;
                        this.textBox1.Text = (string)obj;
                        return;
                    });
                }else
                {
                    this.textBox1.Text = (string)obj;
                }
               // string msg = (string)obj;
               // this.textBox1.Text = msg;
                // MessageBox.Show(msg);
            }
        }

        public FormClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CManagerClientServer.getInstance().connectClientToServer();
                mModelRemoteObject = CManagerClientServer.getInstance().createRemotingObj();
                MessageBox.Show("Connected.");

                mModelRemoteObject.setClient(this);

                this.btnConnect.Enabled = false;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
           // mModelRemoteObject.setClient(this);

            /*
            mModelRemoteObject.setClient(delegate (object p)
            {
                if (p is string)
                {
                    string msg = (string)p;
                    this.textBox1.Text = msg;
                    // MessageBox.Show(msg);
                }
            });
            */

            mModelRemoteObject.sendMessageToHost(textBox1.Text);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (mModelRemoteObject != null)
                {
                    mModelRemoteObject.sendMessageToHost(textBox1.Text);
                }
            }
        }
    }
}
