using System.Collections.Generic;

namespace BT
{
    
    public class BNode
    {
    
        public string name;
    
        protected List<BNode> _children;
        public List<BNode> children { get { return children; } }
    
        public BPrecondition precondition;
    
        public BDatabase database;
    
        public bool actived;
    
        public BNode()
        {
    
        }
    
        public BNode(BPrecondition precondition)
        {
            this.precondition = precondition;
        }

        public virtual void Activate(BDatabase database)
        {
            if (actived) return;

            this.database = database;
            //			Init();

            if (precondition != null)
            {
                precondition.Activate(database);
            }
            if (_children != null)
            {
                foreach (BNode child in _children)
                {
                    child.Activate(database);
                }
            }

            actived = true;
        }


        public virtual BTResult Tick()
        {
            return BTResult.Ended;
        }

        public void AddChild(BNode node)
        {
            if (children == null)
            {
                _children = new List<BNode>();
            }

            if (node != null)
            {
                _children.Add(node);
            }
        }

        public void RemoveChild(BNode node)
        {
            if (children != null && node != null)
            {
                children.Remove(node);
            }
        }

    }

    public enum BTResult
    {
        Ended = 1,
        Running = 2,
    }

}