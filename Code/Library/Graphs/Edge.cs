namespace Library.Graphs
{
    /// <summary>
    /// An edge of a graph.
    /// </summary>
    public class Edge<T>
    {
        /// <summary>
        /// The node this edge leads to.
        /// </summary>
        public Node<T> EndNode { get; protected set; }
        /// <summary>
        /// The weight of this edge.
        /// </summary>
        public double Weight { get; protected set; }

        /// <summary>
        /// Create a new edge object.
        /// </summary>
        /// <param name="endnode">The node this edge should point to.</param>
        /// <param name="weight">The weight this edge should have.</param>
        public Edge(Node<T> endnode, double weight)
        {
            this.EndNode = endnode;
            this.Weight = weight;
        }
    }
}
