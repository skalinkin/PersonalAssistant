using System;
using LiteDB;

namespace PersonalAssistant.InMemmoryStore
{
    internal class Session : IDisposable
    {
        private LiteDatabase db = new LiteDatabase("PersonalAssistant.db");

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Session()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                db?.Dispose();
                db = null;
            }
        }

        public LiteCollection<T> GetCollection<T>() where T : new()
        {
            return db.GetCollection<T>(typeof (T).Name);
        } 
    }
}