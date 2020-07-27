using LibClientServer;
using System;
using System.Windows.Forms;

namespace ClientServerObject
{
    public partial class MainForm : Form
    {
        LibRemotingObj.ModelRemoteObject mModelRemoteObject;

        public MainForm()
        {
            InitializeComponent();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            if (CManagerClientServer.getInstance().openServer(8085))
            {
                MessageBox.Show("Server is Ready!! to transfer and reeive Object!");
                mModelRemoteObject = CManagerClientServer.getInstance().createRemotingObj();

                mModelRemoteObject.setHost(delegate (object obj)
                {
                    if (this.InvokeRequired)
                    {
                        this.BeginInvoke((MethodInvoker)delegate
                        {
                            //string msg = (string)obj;
                            this.textBox1.Text = (string)obj;
                            return;
                        });
                    }
                    else
                    {
                        this.textBox1.Text = (string)obj;
                    }
                });

                this.btnServer.Enabled = false;

            }
            else
            {
                MessageBox.Show("Server is not Ready oops there might be some problem in port!!");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            mModelRemoteObject.sendMessageToClient(textBox1.Text);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(mModelRemoteObject != null)
                {
                    mModelRemoteObject.sendMessageToClient(textBox1.Text);
                }
            }
        }
    }
}
