using System;
using System.Collections.Generic;
using System.Linq;

public static class LevelScript
{
    #region Disney Levels

    private static List<Level> _disneyLevels;
    private static List<Level> DisneyLevels
    {
        get
        {
            if (_disneyLevels == null)
            {
                _disneyLevels = new List<Level>
                {
                    new Level{ LevelText = "I'll be there someday. I can go the distance. I will find my way if I can be strong. – Hercules​​"},
                    new Level {LevelText = "You're braver than you believe, and stronger than you seem, and smarter than you think. - Winnie the Pooh"},
                    new Level {LevelText = "I'm only brave when I have to be. Being brave doesn't mean you go looking for trouble. - Mufasa"},
                    new Level {LevelText = "What I really wanted was to prove that I could do things right, so that when I looked in the mirror, I'd see someone worthwhile. – Mulan​​"},
                    new Level {LevelText = "There are those who say fate is something beyond our command. That destiny is not our own, but I know better. Our fate lives within us, you only have to be brave enough to see it. - Merida"},
                    new Level {LevelText = "The flower that blooms in adversity is the most rare and beautiful of them all. – Mulan"},
                    new Level {LevelText = "Ohana means family, and family means no one gets left behind or forgotten. – Lilo & Stitch"},
                    new Level {LevelText = "The past can hurt. But the way I see it, you can either run from it, or learn from it. – The Lion King"},
                    new Level {LevelText = "In every job that must be done, there is an element of fun. You find the fun and—snap!—the job’s a game! – Mary Poppins"},
                    new Level {LevelText = "She warned him not to be deceived by appearances, for beauty is found within. – Beauty and the Beast"},
                };
            }

            return _disneyLevels;
        }
    }

    public static string GetDisneyLevel()
    {
        return DisneyLevels.OrderBy(x => Guid.NewGuid()).FirstOrDefault().LevelText;
    }

    #endregion

    #region Pop Music Levels

    private static List<Level> _popMusicLevels;
    private static List<Level> PopMusicLevels
    {
        get
        {
            if (_popMusicLevels == null)
            {
                _popMusicLevels = new List<Level>
                {
                    new Level{LevelText = "And you could have it all/ My empire of dirt/ I will let you down/ I will make you hurt. - Nine Inch Nails"},
                    new Level{LevelText = "A skinny man died of a big disease with a little name/ By chance his girlfriend came across a needle and soon she did the same. - Prince"},
                    new Level{LevelText = "And I saw my reflection in the snow-covered hills/ Till the landslide brought me down. - Fleetood Mac"},
                    new Level{LevelText = "There she stood in the doorway/I heard the mission bell/ And I was thinking to myself/ This could be Heaven or this could be Hell. - Eagles"},
                    new Level{LevelText = "When I get older losing my hair/ Many years from now/ Will you still be sending me a Valentine/ Birthday greetings bottle of wine? - The Beatles"},
                    new Level{LevelText = "Heal the world, make it a better place for you and me and the entire human race. There are people dying; if you care enough for the living, make a better place for you and me. - Michael Jackson"},
                    new Level{LevelText = "When you're sure you've had enough of this life, well, hang on. Don't let yourself go, 'cause everybody cries and everybody hurts sometimes. - REM"},
                    new Level{LevelText = "So take the photographs and still frames in your mind. Hang it on a shelf in good health and good time. Tattoos and memories and dead skin on trial. For what it's worth, it was worth all the while. - Green Day"},
                    new Level{LevelText = "Hey, don't write yourself off yet. It's only in your head you feel left out or looked down on. Just do your best (just do your best), do everything you can. And don't you worry what the bitter hearts are gonna say. - Jimmy Eat World"},
                    new Level{LevelText = "Don't it always seem to go, that you don't know what you got 'til it's gone. They paved paradise and put up a parking lot. - Counting Crows"}

                };
            }

            return _popMusicLevels;
        }
    }

    public static string GetPopMusicLevel()
    {
        return PopMusicLevels.OrderBy(x => Guid.NewGuid()).FirstOrDefault().LevelText;
    }

    #endregion

    #region Famous Quotes

    private static List<Level> _famousQuoteLevels;
    private static List<Level> FamousQuoteLevels
    {
        get
        {
            if (_famousQuoteLevels == null)
            {
                _famousQuoteLevels = new List<Level>
                {
                    new Level{ LevelText = "The greatest glory in living lies not in never falling, but in rising every time we fall. - Nelson Mandela"},                    
                    new Level{ LevelText = "Your time is limited, so don't waste it living someone else's life. Don't be trapped by dogma – which is living with the results of other people's thinking. - Steve Jobs"},
                    new Level{ LevelText = "If you look at what you have in life, you'll always have more. If you look at what you don't have in life, you'll never have enough. - Oprah Winfrey"},
                    new Level{ LevelText = "If you set your goals ridiculously high and it's a failure, you will fail above everyone else's success. - James Cameron"},
                    new Level{ LevelText = "Spread love everywhere you go. Let no one ever come to you without leaving happier. - Mother Teresa"},
                    new Level{ LevelText = "The best and most beautiful things in the world cannot be seen or even touched - they must be felt with the heart. - Helen Keller"},
                    new Level{ LevelText = "Many of life's failures are people who did not realize how close they were to success when they gave up. - Thomas A. Edison"},
                    new Level{ LevelText = "You have brains in your head. You have feet in your shoes. You can steer yourself any direction you choose. - Dr. Seuss"},
                    new Level{ LevelText = "The real test is not whether you avoid this failure, because you won't. It's whether you let it harden or shame you into inaction, or whether you learn from it; whether you choose to persevere. - Barack Obama"},
                    new Level{ LevelText = "Always bear in mind that your own resolution to success is more important than any other one thing. - Abraham Lincoln"},
                };
            }

            return _famousQuoteLevels;
        }
    }

    public static string GetFamousQuoteLevel()
    {
        return FamousQuoteLevels.OrderBy(x => Guid.NewGuid()).FirstOrDefault().LevelText;
    }

    #endregion

    public static string GetRandomlevel()
    {
        var tempList = new List<Level>();
        tempList.AddRange(DisneyLevels);
        tempList.AddRange(PopMusicLevels);
        tempList.AddRange(FamousQuoteLevels);

        return tempList.OrderBy(x => Guid.NewGuid()).FirstOrDefault().LevelText;
    }
}

public class Level
{
    public string LevelText { get; set; }
}