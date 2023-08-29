using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SMTP
{

    public partial class MainWindow : Window
    {
        public MailAddress FromAddress { get; set; }
        public MailAddress ToAddress { get; set; }
        public SmtpClient SmtpClient { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            FromAddress = new MailAddress("ayshanorujlu52@gmail.com", "Ayshan Orujlu");
            SmtpClient = new SmtpClient("smtp.gmail.com", 587);
            SmtpClient.Credentials = new NetworkCredential("ayshanorujlu52@gmail.com", "rhoyzvilrinnsfgh");
            SmtpClient.EnableSsl = true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ToAddress = new MailAddress(SendTo_txt.Text);
            var subject = Subject_txt.Text;
            var body = Body_txt.Text;
            Task.Run(() =>
            {
                MailMessage mailMessage = new MailMessage(FromAddress, ToAddress);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                SmtpClient.Send(mailMessage);
                MessageBox.Show($"Message sent to {ToAddress}"!);
                Dispatcher.BeginInvoke(() =>
                {
                    Subject_txt.Clear();
                    Body_txt.Clear();
                    SendTo_txt.Clear();
                });
            });
        }
    }
}
