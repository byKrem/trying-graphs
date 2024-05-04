namespace Graph
{
    public class GraphNode<T>
    {
        private readonly T _baseItem;
        private IEnumerable<GraphNode<T>> _neighborNodes = null!;
        internal GraphNode(T baseItem)
        {
            _baseItem = baseItem;
        }
        public T BaseItem => _baseItem;
        public IEnumerable<GraphNode<T>> NeighborNodes 
        {
            get => _neighborNodes;
            internal set => _neighborNodes = value;
        }
    }
}
