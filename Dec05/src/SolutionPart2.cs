namespace Dec05;

public class SolutionPart2(string inputFile)
{
    
    internal void CalculateSolution()
    {
        var plainInput = File.ReadAllText(inputFile);
        var splitInput = plainInput.Split("\n\n", 2);
        
        var ruleGraph = CreateRuleGraph(splitInput[0]);
        var result = CalculateResult(rawOrders: splitInput[1], ruleGraph);

        Console.WriteLine($"Solution Part 2: {result}");
    }

    private static int CalculateResult(string rawOrders, Dictionary<int, List<int>> ruleGraph)
    {
        var orders = rawOrders
            .Split("\n")
            .Select(orderList => 
                orderList
                    .Split(",")
                    .Select(int.Parse)
                    .ToList()
            ).ToArray();

        var result = orders
            .Where(order => IsOrderFalse(order, ruleGraph))
            .Select(order => SortOrderList(order, ruleGraph))
            .Select(order => order[order.Count / 2])
            .Aggregate(0, (acc, curr) => acc + curr);
        return result;
    }

    private static Dictionary<int, List<int>> CreateRuleGraph(string splitInput)
    {
        var rules = splitInput
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

        return ruleGraph;
    }

    private static List<int> SortOrderList(List<int> order, Dictionary<int, List<int>> ruleGraph)
    {
        for (var orderIndex = 0; orderIndex < order.Count; orderIndex++)
        {
            for (var previousOrderIndex = 0; previousOrderIndex < orderIndex; previousOrderIndex++)
            {
                if (!ruleGraph.ContainsKey(order[orderIndex]))
                {
                    continue;
                }
                if (ruleGraph[order[orderIndex]].Contains(order[previousOrderIndex]))
                {
                    var item = order[orderIndex];
                    order.RemoveAt(orderIndex);
                    order.Insert(previousOrderIndex, item);
                    return SortOrderList(order, ruleGraph);
                }
            }
        }

        return order;
    }

    private static bool IsOrderFalse(List<int> order, Dictionary<int, List<int>> ruleGraph)
    {
        for (var orderIndex = 0; orderIndex < order.Count; orderIndex++)
        {
            for (var previousOrderIndex = 0; previousOrderIndex < orderIndex; previousOrderIndex++)
            {
                if (!ruleGraph.ContainsKey(order[orderIndex]))
                {
                    continue;
                }
                if (ruleGraph[order[orderIndex]].Contains(order[previousOrderIndex]))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static void AddNodesToGraph(
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
}