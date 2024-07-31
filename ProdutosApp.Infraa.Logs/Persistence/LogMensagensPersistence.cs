using ProdutosApp.Infraa.Logs.Collections;
using ProdutosApp.Infraa.Logs.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Infraa.Logs.Persistence
{
    public class LogMensagensPersistence
    {
        public void Insert(LogMensagens log)
        {
            var mongoDBContext = new MongoDBContext();
            mongoDBContext.LogMensagens.InsertOne(log);
        }
    }
}
