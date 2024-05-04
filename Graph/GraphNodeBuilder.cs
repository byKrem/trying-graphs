namespace Graph
{
    public class GraphNodeBuilder<T>
    {
        private T _baseItem;
        private List<GraphNode<T>> _neighborNodes;

        public GraphNodeBuilder(T item) 
        {
            _baseItem = item;
            _neighborNodes = [];
        }

        public void AddNeighbor(GraphNode<T> neighbor)
        {
            _neighborNodes.Add(neighbor);
        }
        public void AddNeighbor(T neighbor)
        {
            _neighborNodes.Add(new GraphNode<T>(neighbor));
        }

        public GraphNode<T> Create()
        {
            return new GraphNode<T>(_baseItem)
            {
                NeighborNodes = _neighborNodes
            };
        }
    }
}
