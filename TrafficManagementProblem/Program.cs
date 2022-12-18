namespace TrafficManagementProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var areaManager = new AreaManager();
        }
    }

    /*
    Sivile flyplassen har spesifikke områder i luftrommet i nærheten som har bra utsikt over R&D klassifiserte militæroperasjoner.

    Et radarsystem skal installeres hos militærbasen, og er koblet til et missilsystem. HVIS et fly FLYR INN i WARNING ZONE vil missilsystemet gjøre seg klart
    og kryptisk advare piloten. Inne i firezone så vil flyet bli skutt ned.            
    
    // The remaining pilots will probably learn to sly in the safe area eventually.// Logge koordinatene der flyene blir skutt ned og hindre andre i å fly dit?

    Fly - Trenger hver sin ID.   Formatet er: id(x,y). Ha en liste med disse flyene?
    The list of planes in the aerospace is space separated and send to standard input every second (thread.sleep(1000)) (orso) as a line. For example: FR664(10,2) GB3265(4,9) NO5521(3,3)
    
    After the planes’ locations have been given, we expect you to print (line separated) either nothing, Warning [plane id]
    or Shooting [plane id] at [plane coordinates]. For example: Warning GB3265, Shooting FR664 at (10,2)
    */
}