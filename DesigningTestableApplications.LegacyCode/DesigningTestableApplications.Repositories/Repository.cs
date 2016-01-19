using System;
using System.Collections.Generic;
using DesigningTestableApplications.ORM;

namespace DesigningTestableApplications.Repositories
{
    public abstract class Repository
    {
        private static DesigningTestableApplicationsEntities context;

        public static DesigningTestableApplicationsEntities Context
        {
            get
            {
                //NO ES THREAD-SAFE!! Solo para ejemplo!
                if (context == null)
                {
                    context = new DesigningTestableApplicationsEntities();
                    context.Configuration.LazyLoadingEnabled = false;
                }

                return context;
            }
        }
    }
}
