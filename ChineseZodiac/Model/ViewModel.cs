using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ChineseZodiac.Model
{
    public class ViewModel
    {
        public List<Zodiac> ChineseZodiac { get; set; }

        public ViewModel()
        {
            ChineseZodiac = new List<Zodiac>();

            Zodiac rat = new Zodiac() { Name = "Rat", Side = Side.Yang, Element = Element.Water, Trine = 1, Description = "Forthright, disciplined, systematic, meticulous, charismatic, hardworking, industrious, charming, eloquent, sociable, shrewd. Can be manipulative, cruel, dictatorial, rigid, selfish, obstinate, critical, over-ambitious, ruthless, intolerant, scheming, sturdy", ImageSource = "Resources/Images/Zodiac/Rat-000.png" };
            Zodiac ox = new Zodiac() { Name = "Ox", Side = Side.Yin, Element = Element.Water, Trine = 2, Description = "Dependable, calm, methodical, patient, hardworking, ambitious, conventional, steady, modest, logical, resolute, tenacious. Can be stubborn, narrow-minded, materialistic, rigid, demanding", ImageSource = "Resources/Images/Zodiac/Ox-000.png" };
            Zodiac tiger = new Zodiac() { Name = "Tiger", Side = Side.Yang, Element = Element.Wood, Trine = 3, Description = "Unpredictable, rebellious, colourful, powerful, passionate, daring, impulsive, vigorous, stimulating, sincere, affectionate, humanitarian, generous. Can be restless, reckless, impatient, quick-tempered, obstinate, selfish", ImageSource = "Resources/Images/Zodiac/Tiger-000.png" };
            Zodiac rabbit = new Zodiac() { Name = "Rabbit", Side = Side.Yin, Element = Element.Wood, Trine = 4, Description = "Gracious, kind, sensitive, soft-spoken, amiable, elegant, reserved, cautious, artistic, thorough, tender, self-assured, astute, compassionate, flexible. Can be moody, detached, superficial, self-indulgent, opportunistic, lazy", ImageSource = "Resources/Images/Zodiac/Rabbit-000.png" };
            Zodiac dragon = new Zodiac() { Name = "Dragon", Side = Side.Yang, Element = Element.Wood, Trine = 1, Description = "Magnanimous, stately, vigorous, strong, self-assured, proud, noble, direct, dignified, zealous, fiery, passionate, decisive, pioneering, ambitious, generous, loyal. Can be arrogant, imperious, tyrannical, demanding, eccentric, grandiloquent and extremely bombastic, prejudiced, dogmatic, over-bearing, violent, impetuous, brash", ImageSource = "Resources/Images/Zodiac/Dragon-000.png" };
            Zodiac snake = new Zodiac() { Name = "Snake", Side = Side.Yin, Element = Element.Fire, Trine = 2, Description = "Deep thinker, wise, mystic, graceful, soft-spoken, sensual, creative, prudent, shrewd, ambitious, elegant, cautious, responsible, calm, strong, constant, purposeful. Can be loner, bad communicator, possessive, hedonistic, self-doubting, distrustful, mendacious", ImageSource = "Resources/Images/Zodiac/Snake-000.png" };
            Zodiac horse = new Zodiac() { Name = "Horse", Side = Side.Yang, Element = Element.Fire, Trine = 3, Description = "Cheerful, popular, quick-witted, changeable, earthy, perceptive, talkative, agile mentally and physically, magnetic, intelligent, astute, flexible, open-minded. Can be fickle, anxious, rude, gullible, stubborn, lack stability and perseverance", ImageSource = "Resources/Images/Zodiac/Horse-000.png" };
            Zodiac sheep = new Zodiac() { Name = "Sheep", Side = Side.Yin, Element = Element.Fire, Trine = 4, Description = "Righteous, sincere, sympathetic, mild-mannered, shy, artistic, creative, gentle, compassionate, understanding, mothering, determined, peaceful, generous, seeks security. Can be moody, indecisive, over-passive, worrier, pessimistic, over-sensitive, complainer", ImageSource = "Resources/Images/Zodiac/Goat-000.png" };
            Zodiac monkey = new Zodiac() { Name = "Monkey", Side = Side.Yang, Element = Element.Metal, Trine = 1, Description = "Inventor, motivator, improviser, quick-witted, inquisitive, flexible, innovative, problem solver, self-assured, sociable, polite, dignified, competitive, objective, factual, intellectual. Can be egotistical, vain, selfish, cunning, jealous, suspicious", ImageSource = "Resources/Images/Zodiac/Monkey-000.png" };
            Zodiac rooster = new Zodiac() { Name = "Rooster", Side = Side.Yin, Element = Element.Metal, Trine = 2, Description = "Acute, neat, meticulous, organized, self-assured, decisive, conservative, critical, perfectionist, alert, zealous, practical, scientific, responsible. Can be over zealous and critical, puritanical, egotistical, abrasive, opinionated", ImageSource = "Resources/Images/Zodiac/Rooster-000.png" };
            Zodiac dog = new Zodiac() { Name = "Dog", Side = Side.Yang, Element = Element.Metal, Trine = 3, Description = "Honest, intelligent, straightforward, loyal, sense of justice and fair play, attractive, amiable, unpretentious, sociable, open-minded, idealistic, moralistic, practical, affectionate, dogged. Can be cynical, lazy, cold, judgmental, pessimistic, worrier, stubborn, quarrelsome", ImageSource = "Resources/Images/Zodiac/Dog-000.png" };
            Zodiac pig = new Zodiac() { Name = "Pig", Side = Side.Yin, Element = Element.Water, Trine = 4, Description = "Honest, simple, gallant, sturdy, sociable, peace-loving, patient, loyal, hard-working, trusting, sincere, calm, understanding, thoughtful, scrupulous, passionate, intelligent. Can be naive, over-reliant, self-indulgent, gullible, fatalistic, materialistic", ImageSource = "Resources/Images/Zodiac/Pig-000.png" };

            ChineseZodiac.Add(rat);
            ChineseZodiac.Add(ox);
            ChineseZodiac.Add(tiger);
            ChineseZodiac.Add(rabbit);
            ChineseZodiac.Add(dragon);
            ChineseZodiac.Add(snake);
            ChineseZodiac.Add(horse);
            ChineseZodiac.Add(sheep);
            ChineseZodiac.Add(monkey);
            ChineseZodiac.Add(rooster);
            ChineseZodiac.Add(dog);
            ChineseZodiac.Add(pig);

            ChineseZodiac.Add(rat);
            ChineseZodiac.Add(ox);
            ChineseZodiac.Add(tiger);
            ChineseZodiac.Add(rabbit);
            ChineseZodiac.Add(dragon);
            ChineseZodiac.Add(snake);
            ChineseZodiac.Add(horse);
            ChineseZodiac.Add(sheep);
            ChineseZodiac.Add(monkey);
            ChineseZodiac.Add(rooster);
            ChineseZodiac.Add(dog);
            ChineseZodiac.Add(pig);

            ChineseZodiac.Add(rat);
            ChineseZodiac.Add(ox);
            ChineseZodiac.Add(tiger);
            ChineseZodiac.Add(rabbit);
            ChineseZodiac.Add(dragon);
            ChineseZodiac.Add(snake);
            //ChineseZodiac.Add(horse);
            //ChineseZodiac.Add(sheep);
            //ChineseZodiac.Add(monkey);
            //ChineseZodiac.Add(rooster);
            //ChineseZodiac.Add(dog);
            //ChineseZodiac.Add(pig);
        }
    }
}
