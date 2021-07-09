using System;
using System.IO;
using System.Net;
using System.Text;
using ElectronicQueue.Common;

namespace Testing_Nancyfx_wnc
{
    public class EQAgent
    {
        public EQAgentOptions Options { private set; get; }

        public EQAgent()
        {
            Options = new EQAgentOptions();
            Options.GUID = new Guid("009bac39-d16d-4473-a0dc-7f8e73c9370d");
        }

        public bool GetCategories(ref CategoryList _CategoryList)
        {
            try
            {
                string StrUrl = "http://localhost:12347/registration/categories";
                WebRequest request = WebRequest.Create(StrUrl);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Timeout = Options.DispatcherTimeout * 1000;
                
                TransportedData Data = new TransportedData();
                Data.GUID = Options.GUID;
                Data.Data = null;

                byte[] byteArray = Encoding.UTF8.GetBytes(Data.ToJson());
                request.ContentLength = byteArray.Length;
                using (Stream dataStream = request.GetRequestStream())
                    dataStream.Write(byteArray, 0, byteArray.Length);
                
                WebResponse response = request.GetResponse();
                Stream responseDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseDataStream);

                string Res = reader.ReadToEnd();
                try
                {
                    _CategoryList = new CategoryList();
                    _CategoryList.Categories = CategoryList.FromJson(Res);
                }
                catch (Exception e)
                {
                    throw new Exception("Ошибка десереализации списка категорий", e);
                }
                return true;
            }
            catch (WebException e)
            {
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

