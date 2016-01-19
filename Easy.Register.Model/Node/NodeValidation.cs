using Easy.Domain.Validators;

namespace Easy.Register.Model
{
    public class NodeValidation : EntityValidation<Node>
    {
        public NodeValidation()
        {
            this.IsNullOrWhiteSpace(m => m.Url, NodeBrokenRuleMessage.UrlIsEmpty);
            this.IsNullOrWhiteSpace(m => m.Ip, NodeBrokenRuleMessage.IPIsEmpty);
            this.GreaterThan(m => m.DirectoryInfo.Id, 0, NodeBrokenRuleMessage.DirectoryIdError);
            this.AddRule((n) => {

                return !RepositoryRegistry.Node.IsExists(n);
            
            
            }, NodeBrokenRuleMessage.NodeIsExists);
        }
    }
}
