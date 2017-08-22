using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace RNS
{
   public class aclient
    {
        public void Client( String notice,String category)
        {
            //MessageBox.Show("client executed");
            UdpClient client = new UdpClient();
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("169.254.255.255"), 3232); // endpoint where server is listening
            client.Connect(ep);

            //string to byte conversion
            byte[] array = Encoding.ASCII.GetBytes(notice);
            byte[] array1 = Encoding.ASCII.GetBytes(category);
            // send data
            client.Send(array, array.Length);
            client.Send(array1,array1.Length);
            
        }
    }
}
