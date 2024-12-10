internal class SolutionPart1(string inputFile)
{
    
    internal void CalculateSolution()
    {
        var plainInput = File.ReadAllText(inputFile);
        var splitInput = plainInput.Split("\n\n", 2);
        
        var rules = splitInput[0]
            .Split("\n")
            .Select(line =>
            {
                var textRules = line
                    .Split("|", 2)
                    .Select(int.Parse)
                    .ToArray();
                return new Rule(textRules[0], textRules[1]);
            });
        var ruleGraph = new Dictionary<int, List<int>>();
        foreach (var rule in rules)
        {
            AddNodesToGraph(
                rule.BigNode, 
                rule.SmallNode, 
                ruleGraph);
        }
        PrintRuleGraph(ruleGraph);
        
        var orders = splitInput[1]
            .Split("\n")
            .Select(orderList => 
                orderList
                .Split(",")
                .Select(int.Parse)
                .ToList()
            ).ToArray();

        // Console.WriteLine($"Rules: \n{splitInput[0]}");
        // Console.WriteLine($"Orders: \n{splitInput[1]}");

        var filteredOrders = orders
            .Where(order => IsOrderCorrect(order, ruleGraph))
            .Select(order => order[order.Count / 2])
            .Aggregate(0, (acc, curr) => acc + curr);

        Console.WriteLine($"Solution Part 1: {filteredOrders}");
    }
    
    internal bool IsOrderCorrect(List<int> order, Dictionary<int, List<int>> ruleGraph)
    {
        for (var i = 0; i < order.Count; i++)
        {
            for (var j = 0; j < i; j++)
            {
                if (!ruleGraph.ContainsKey(order[i]))
                {
                    continue;
                }
                if (ruleGraph[order[i]].Contains(order[j]))
                {
                    return false;
                }
            }
        }

        return true;
    }
    
    internal void AddNodesToGraph(
        int node, 
        int smallerNode, 
        Dictionary<int, List<int>> graph)
    {
        if (!graph.ContainsKey(node))
        {
            graph[node] = [smallerNode];
        }
        else
        {
            if (!graph[node].Contains(smallerNode)) 
            {
                graph[node].Add(smallerNode);
            }
        }
    }
    
    internal void PrintRuleGraph(Dictionary<int, List<int>> ruleGraph)
    {
        foreach (var (node, smallerNodes) in ruleGraph)
        {
            var nodes = "";
            foreach (var smallerNode in smallerNodes)
            {
                nodes += smallerNode.ToString() + ", ";
            }
            Console.WriteLine("Node " + node.ToString() + ": [" + nodes + "]");
        }
    }
}

internal record Rule(int BigNode, int SmallNode);