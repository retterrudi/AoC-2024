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
        
        var orders = splitInput[1].Split("\n");

        // Console.WriteLine($"Rules: \n{splitInput[0]}");
        // Console.WriteLine($"Orders: \n{splitInput[1]}");
        

        

    }
    
    internal bool IsOrderCorrect(string order, Dictionary<int, List<int>> ruleGraph)
    {
        var listItems = order
            .Split(",")
            .Select(int.Parse)
            .ToList();

        for (var i = listItems.Count - 1; i >= 0; i--)
        {
            
            
        }
    }
    
    internal bool IsWrongOrder(int node, List<int> nodes, Dictionary<int, List<int>> ruleGraph)
    {
        List<int> closedNodes = [];
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