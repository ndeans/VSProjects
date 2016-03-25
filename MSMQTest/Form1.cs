using System;

using System.Text;
using System.Windows.Forms;
using System.Messaging;
using static MSMQTest.Program;

namespace MSMQTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Payment myPayment;

            myPayment.Payor = textBox1.Text;
            myPayment.Payee = textBox2.Text;
            int i = Convert.ToInt32(textBox3.Text);
            myPayment.Amount = i;
            myPayment.DueDate = textBox4.Text;

            System.Messaging.Message msg = new System.Messaging.Message();
            msg.Body = myPayment;

            MessageQueue msgQ = new MessageQueue(".\\private$\\testqueue");
            msgQ.Send(textBox1.Text);

        }


        private void button2_Click(object sender, EventArgs e)
        {

            MessageQueue msgQ = new MessageQueue(".\\private$\\testqueue");

            Payment myPayment = new Payment();
            Object o = new object();
            System.Type[] arrTypes = new System.Type[2];
            arrTypes[0] = myPayment.GetType();
            arrTypes[1] = o.GetType();
            msgQ.Formatter = new XmlMessageFormatter(arrTypes);
            myPayment = ((Payment)msgQ.Receive().Body);

            StringBuilder sb = new StringBuilder();
            sb.Append("Payment paid to: " + myPayment.Payor);
            sb.Append("\n");
            sb.Append("Paid by: " + myPayment.Payee);
            sb.Append("\n");
            sb.Append("Amount: $" + myPayment.Amount.ToString());
            sb.Append("\n");
            sb.Append("Due Date: " + Convert.ToDateTime(myPayment.DueDate));

            MessageBox.Show(sb.ToString(), "Message Received!");
            
        }

    }
}
