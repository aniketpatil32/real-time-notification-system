using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;

namespace RNS
{
   public class aserver
    {
        
        public void Server()
        {
            try
            {

                //MessageBox.Show("server is running");
                UdpClient udpServer = new UdpClient(3232);
                String final;
                String category;
                while (true)
                {
                    var remoteEP = new IPEndPoint(IPAddress.Any, 3232);
                    var data = udpServer.Receive(ref remoteEP);
                    var type = udpServer.Receive(ref remoteEP);
                    // listen on port 11000
                    Console.Write("receive data from " + remoteEP.ToString());
                    final = System.Text.Encoding.UTF8.GetString(data);
                    category = System.Text.Encoding.UTF8.GetString(type);
                    MessageBox.Show(final,category);
                    //udpServer.Close();
                }
                //udpServer.Send(new byte[] { 1 }, 1, remoteEP); // reply back
            }
            catch (Exception e)
            {
                
               
               
            }
            
        }
    }
}
