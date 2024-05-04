using Models;

namespace Graph.Tests
{
    public class GraphNodeTests
    {
        Queue<GraphNode<Person>> _personsQueue;

        [SetUp]
        public void Setup()
        {
            _personsQueue = new();

            GraphNodeBuilder<Person> builderAlex = new(new Person("Alex"));
            GraphNodeBuilder<Person> builderAnny = new(new Person("Anny"));
            GraphNodeBuilder<Person> builderMax = new(new Person("Max"));
            GraphNodeBuilder<Person> builderOleg = new(new Person("Oleg"));

            builderMax.AddNeighbor(builderOleg.Create());

            builderAlex.AddNeighbor(builderAnny.Create());
            builderAlex.AddNeighbor(builderMax.Create());
            
            var alex = builderAlex.Create();
            _personsQueue.Enqueue(alex);
        }

        [Test]
        public void WideSearchTest()
        {
            if (_personsQueue.Count != 1) 
            {
                Assert.Fail();
            }

            bool isFinded = false;

            while(_personsQueue.Count != 0)
            {
                var person = _personsQueue.Dequeue();
                if (person.BaseItem.Name.Equals("Max"))
                {
                    isFinded = true;
                    break;
                }

                foreach(var item in person.NeighborNodes)
                {
                    _personsQueue.Enqueue(item);
                }
            }

            if (!isFinded)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }
    }
}