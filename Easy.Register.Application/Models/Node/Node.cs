using System;

namespace Easy.Register.Application.Models.Node
{
    public class Node
    {
        public Node(int id, int directoryId,string providerName, string ip, string url, int weight, bool isAvaiable,string description)
        {
            this.Id = id;
            this.DirectoryId = directoryId;
            this.ProviderName = providerName;
            this.Ip = ip;
            this.Url = url;
            this.Weight = weight;
            this.IsAvailable = isAvaiable;
            this.Description = description;
        }

        public int Id { get; private set; }

        public int DirectoryId { get; private set; }
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
