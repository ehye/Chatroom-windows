using ComLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Server
{
    class VerySimpleChatServer
    {
        TcpListener listener;
        List<NetworkStream> clientOutputStreams;

        public void Go()
        {
            try
            {
                TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 6017);
                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    NetworkStream stream = tcpClient.GetStream();
                    clientOutputStreams.Add(stream);
                    ClientHandler clientHandler = new ClientHandler(tcpClient);
                    Thread t = new Thread(new ThreadStart(clientHandler.Run));
                    t.Start();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        //public IEnumerator<NetworkStream> GetEnumerator()
        //{
        //    var i = clientOutputStreams.GetEnumerator();
        //    while (i.MoveNext())
        //    {
        //        try
        //        {
        //            i.Current.WriteByte()
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }

        //    }
        //    yield return default(NetworkStream);
        //}

        public void Telleveryone(string message)
        {
            var i = clientOutputStreams.GetEnumerator();
            while (i.MoveNext())
            {
                try
                {
                    i.Current.WriteByte(Byte.Parse(message));
                    i.Current.Flush();
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        private class ClientHandler
        {
            TcpClient tcpClient;
            NetworkStream networkStream;
            StreamReader streamReader;

            public ClientHandler(TcpClient tcpClient)
            {
                //try
                //{
                //    // Deserilaize the client objet form stream.
                //    var formatter = new BinaryFormatter();
                //    var handler = listener.AcceptTcpClient();
                //    var stream = handler.GetStream();

                //}
                //catch (Exception) { throw; }
                try
                {
                    this.tcpClient = tcpClient;
                    var stream = tcpClient.GetStream();
                    streamReader = new StreamReader(stream);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            public void Run()
            {
                //while (true)
                //{
                //    try
                //    {
                //        Mail client = (Mail)formatter.Deserialize(stream);

                //    }
                //    catch (Exception)
                //    {

                //        throw;
                //    }
                //}
                string message;
                while ((message = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(message);
                }
            }

        }
    }
}
