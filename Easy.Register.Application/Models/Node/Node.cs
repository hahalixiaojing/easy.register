using System;

namespace Easy.Register.Application.Models.Node
{
    public class Node
    {
        public Node(int id, string providerName, string ip, string url, int weight, bool isAvaiable)
        {
            this.Id = id;
            this.ProviderName = providerName;
            this.Url = url;
            this.Weight = weight;
            this.IsAvailable = isAvaiable;
        }

        public int Id { get; private set; }
        public String ProviderName
        {
            get;
            private set;
        }
        public string Ip
        {
            get;
            private set;
        }
        public String Url
        {
            get;
            private set;
        }
        public Int32 Weight
        {
            get;
            private set;
        }
        public Boolean IsAvailable
        {
            get;
            private set;
        }
    }
}
