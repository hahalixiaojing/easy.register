using System;

namespace Easy.Register.Application.Models.Node
{
    public class Node
    {
        public Node(int id, int dirId,string providerName, string ip, string url, int weight, bool isAvaiable,string description)
        {
            this.Id = id;
            this.DirId = dirId;
            this.ProviderName = providerName;
            this.Ip = ip;
            this.Url = url;
            this.Weight = weight;
            this.IsAvailable = isAvaiable;
            this.Description = description;
        }

        public int Id { get; private set; }

        public int DirId { get; private set; }
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
        public string Description { get; private set; }
    }
}
