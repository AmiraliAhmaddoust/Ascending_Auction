


int[,] v = { { 8, 5, 9, 4 }, { 4, 11, 7, 4 }, { 9, 7, 6, 4 } };
int[] r = { 2, 1, 0 };
int ϵ = 1;

AscendingBidAuction auction_1 = new AscendingBidAuction(v, r, ϵ);
auction_1.start();

class AscendingBidAuction
{
    private int[,] v;
    private int[] r;
    private int ϵ;
    private int n, m;
    private int[] houseList;

    public List<Value_EachHome_For_Buyers> HomesValue = new List<Value_EachHome_For_Buyers>();
    int counter = 0;

    public List<HistoryHolder> historyHolder = new List<HistoryHolder>();

    int max0 = 0;
    int max1 = 0;
    int max2 = 0;
    public AscendingBidAuction(int[,] v, int[] r, int ϵ)
    {
        this.v = v;
        this.r = r;
        this.ϵ = ϵ;
        this.n = v.GetLength(0);
        this.m = v.GetLength(1);
    }

    public void start()
    {
        Console.WriteLine("The Ascending Bid Auction for Houses");
        Console.WriteLine();

        Console.WriteLine("Basic Information: " + this.n + " houses, " + this.m + " buyers");

        Console.WriteLine("The valuation matrix is as follows");
        Console.WriteLine("Buyer Number " + string.Join(" ", Enumerable.Range(0, this.m)));
        for (int i = 0; i < this.n; i++)
        {
            Console.WriteLine("House " + i + " " + string.Join(" ", Enumerable.Range(0, this.m).Select(j => this.v[i, j])));
        }
        Console.WriteLine();



        for (int i = 0; i < v.GetLength(0); i++)
        {
            for (int j = 0; j < v.GetLength(1); j++)
            {
                Value_EachHome_For_Buyers a = new Value_EachHome_For_Buyers();
                a.HomeNumber = i;
                a.Buyer_Number = j;
                a.MaxValueForBuyer = v[i, j];
                if (i == 0)
                {
                    a.Home_Start_Value = 2;
                }
                else if (i == 1)
                {
                    a.Home_Start_Value = 1;
                }
                else
                {
                    a.Home_Start_Value = 0;
                }

                HomesValue.Add(a);
            }
        }

        do
        {
            Strategy();


        } while (Check_Termination_Condition() == false);


        int RoundCounter = 0;

        foreach (var item2 in historyHolder)
        {
            Console.WriteLine("Round Number : " + RoundCounter);
            Console.WriteLine("Auction For First Home");
            foreach (var item in item2.Bids)
            {

                if (item.BuyerHomeNumber == 0)
                {

                    Console.WriteLine("Buyer Number :" + item.BuyerNumber + " buyer Bid Offer :" + item.BuyerBidPrice);

                }
            }
            foreach (var aa in item2.Bids)
            {
                if (aa.BuyerHomeNumber == 0)
                {
                    if (aa.IsWinner == true)
                    {
                        Console.WriteLine("the winner Number is :" + aa.BuyerNumber);
                    }
                }
            }
            Console.WriteLine("Auction For second Home");
            foreach (var item in item2.Bids)
            {
                if (item.BuyerHomeNumber == 1)
                {

                    Console.WriteLine("Buyer Number :" + item.BuyerNumber + " buyer Bid Offer :" + item.BuyerBidPrice);

                }
            }
            foreach (var aa in item2.Bids)
            {
                if (aa.BuyerHomeNumber == 1)
                {
                    if (aa.IsWinner == true)
                    {
                        Console.WriteLine("the winner Number is :" + aa.BuyerNumber);
                    }
                }
            }
            Console.WriteLine("Auction For third Home");
            foreach (var item in item2.Bids)
            {
                if (item.BuyerHomeNumber == 2)
                {

                    Console.WriteLine("Buyer Number :" + item.BuyerNumber + " buyer Bid Offer :" + item.BuyerBidPrice);

                }
            }
            foreach (var aa in item2.Bids)
            {
                if (aa.BuyerHomeNumber == 2)
                {
                    if (aa.IsWinner == true)
                    {
                        Console.WriteLine("the winner Number is :" + aa.BuyerNumber);
                    }
                }
            }


            RoundCounter++;
        }
    }
    public bool Check_Termination_Condition()
    {
        if (historyHolder[historyHolder.Count - 1].Bids.Count == 3)
        {
            return true;
        }
        else
            return false;
    }
    public void IsWinner()
    {

        Bid winner0 = new Bid();
        Bid winner1 = new Bid();
        Bid winner2 = new Bid();
        int counter0 = 0;
        int counter1 = 0;
        int counter2 = 0;
        foreach (var item in historyHolder[historyHolder.Count - 1].Bids)
        {
            if (item.BuyerHomeNumber == 0)
            {
                if (counter0 == 0)
                {
                    winner0 = item;
                    counter0++;
                }
                else
                {
                    if (winner0.BuyerBidPrice < item.BuyerBidPrice)
                    {

                        winner0 = item;
                    }
                    else if (winner0.BuyerBidPrice > item.BuyerBidPrice)
                    {

                    }
                    else
                    {
                        Random random = new Random();
                        int ra = random.Next(0, 10);
                        if (ra > 5)
                        {
                            winner0 = item;
                        }
                    }
                }

            }

            if (item.BuyerHomeNumber == 1)
            {
                if (counter1 == 0)
                {
                    winner1 = item;
                    counter1++;
                }
                else
                {
                    if (winner1.BuyerBidPrice < item.BuyerBidPrice)
                    {

                        winner1 = item;
                    }
                    else if (winner1.BuyerBidPrice > item.BuyerBidPrice)
                    {

                    }
                    else
                    {
                        Random random = new Random();
                        int ra = random.Next(0, 10);
                        if (ra > 5)
                        {
                            winner1 = item;
                        }
                    }
                }

            }

            if (item.BuyerHomeNumber == 2)
            {
                if (counter2 == 0)
                {
                    winner2 = item;
                    counter2++;
                }
                else
                {
                    if (winner2.BuyerBidPrice < item.BuyerBidPrice)
                    {

                        winner2 = item;
                    }
                    else if (winner2.BuyerBidPrice > item.BuyerBidPrice)
                    {

                    }
                    else
                    {
                        Random random = new Random();
                        int ra = random.Next(0, 10);
                        if (ra > 5)
                        {
                            winner2 = item;
                        }
                    }
                }

            }
        }

        foreach (var item in historyHolder[historyHolder.Count - 1].Bids)
        {
            if (item.BuyerBidPrice == winner0.BuyerBidPrice && item.BuyerNumber == winner0.BuyerNumber && item.BuyerHomeNumber == winner0.BuyerHomeNumber)
            {
                item.IsWinner = true;
                max0 = item.BuyerBidPrice;

            }
            if (item.BuyerBidPrice == winner1.BuyerBidPrice && item.BuyerNumber == winner1.BuyerNumber && item.BuyerHomeNumber == winner1.BuyerHomeNumber)
            {
                item.IsWinner = true;
                max1 = item.BuyerBidPrice;
            }
            if (item.BuyerBidPrice == winner2.BuyerBidPrice && item.BuyerNumber == winner2.BuyerNumber && item.BuyerHomeNumber == winner2.BuyerHomeNumber)
            {
                item.IsWinner = true;
                max2 = item.BuyerBidPrice;
            }
        }
    }

    public void Strategy()
    {
        List<Bid> bids = new List<Bid>();
        if (counter == 0)
        {
            counter++;
            foreach (var item in HomesValue)
            {
                bids.Add(new Bid(item.Buyer_Number, item.Home_Start_Value, item.HomeNumber, false));
            }
            historyHolder.Add(new HistoryHolder(bids, counter));
        }
        else
        {
            IsWinner();
            foreach (var item in historyHolder[historyHolder.Count - 1].Bids)
            {

                if (item.IsWinner == true)
                {
                    bids.Add(new Bid(item.BuyerNumber, item.BuyerBidPrice, item.BuyerHomeNumber, false));
                }
                else
                {
                    for (int i = 0; i < HomesValue.Count; i++)
                    {
                        if (HomesValue[i].HomeNumber == item.BuyerHomeNumber && HomesValue[i].Buyer_Number == item.BuyerNumber)
                        {
                            int max = HomesValue[i].MaxValueForBuyer;
                            if (item.BuyerHomeNumber == 0)
                            {
                                if (max >= max0 + ϵ)
                                {
                                    bids.Add(new Bid(item.BuyerNumber, max0 + ϵ, item.BuyerHomeNumber, false));
                                }
                            }
                            if (item.BuyerHomeNumber == 1)
                            {
                                if (max >= max1 + ϵ)
                                {
                                    bids.Add(new Bid(item.BuyerNumber, max1 + ϵ, item.BuyerHomeNumber, false));
                                }
                            }
                            if (item.BuyerHomeNumber == 2)
                            {
                                if (max >= max2 + ϵ)
                                {
                                    bids.Add(new Bid(item.BuyerNumber, max2 + ϵ, item.BuyerHomeNumber, false));
                                }
                            }
                        }
                    }

                }

            }
            historyHolder.Add(new HistoryHolder(bids, counter));
            counter++;
        }
    }
}
public class Value_EachHome_For_Buyers
{
    public int Buyer_Number;
    public int HomeNumber;
    public int MaxValueForBuyer;
    public int Home_Start_Value;
}
public class Bid
{
    public int BuyerNumber;
    public int BuyerBidPrice;
    public int BuyerHomeNumber;
    public bool IsWinner;
    public Bid(int BuyerNumber, int BuyerBidPrice, int BuyerHomeNumber, bool IsWinner)
    {
        this.BuyerNumber = BuyerNumber;
        this.BuyerBidPrice = BuyerBidPrice;
        this.BuyerHomeNumber = BuyerHomeNumber;
        this.IsWinner = IsWinner;
    }
    public Bid()
    {

    }
}

public class HistoryHolder
{
    public List<Bid> Bids = new List<Bid>();
    public int round;

    public HistoryHolder(List<Bid> Bids, int round)
    {
        this.Bids = Bids;
        this.round = round;
    }
}
