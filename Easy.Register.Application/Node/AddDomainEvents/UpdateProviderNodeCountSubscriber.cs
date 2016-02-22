using Easy.Register.Application.Models.Node;

namespace Easy.Register.Application.Node.AddDomainEvents
{
    class UpdateProviderNodeCountSubscriber : NodePublishSubscriber
    {

        public override void HandleEvent(NodeDomainEvent aDomainEvent)
        {
            int nodeCount = aDomainEvent.Nodes.Count;

            int directoryId = 0;
            if(aDomainEvent.Nodes.Count > 0)
            {
                directoryId = aDomainEvent.Nodes[0].DirectoryId;
            }
            Model.RepositoryRegistry.Directory.UpdateProviderNodeCount(directoryId, nodeCount);
        }
    }
}
