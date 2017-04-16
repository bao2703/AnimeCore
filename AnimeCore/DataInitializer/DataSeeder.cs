using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Entities.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AnimeCore.DataInitializer
{
    public static class DataSeeder
    {
        private static string ConvertUrl(string url)
        {
            return "http://onecloud.media/embed/" + url.Split('/')[4];
        }

        public static async Task InitializeAsync(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetService<NeptuneContext>();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            #region genres

            const string action = "Action";
            const string adventure = "Adventure";
            const string comedy = "Comedy";
            const string ecchi = "Ecchi";
            const string drama = "Drama";
            const string detective = "Detective";
            const string fantasy = "Fantasy";
            const string game = "Game";
            const string harem = "Harem";
            const string historical = "Historical";
            const string horror = "Horror";
            const string josei = "Josei";
            const string magic = "Magic";
            const string mecha = "Mecha";
            const string military = "Military";
            const string musical = "Musical";
            const string mystery = "Mystery";
            const string parody = "Parody";
            const string psychological = "Psychological";
            const string romance = "Romance";
            const string schoolLife = "School Life";
            const string sciFi = "Sci-Fi";
            const string seinen = "Seinen";
            const string shoujo = "Shoujo";
            const string shounen = "Shounen";
            const string sports = "Sports";
            const string superNatural = "Super Natural";
            const string superPower = "Super Power";
            const string tragedy = "Tragedy";
            const string vampire = "Vampire";

            var genres = new Dictionary<string, Genre>
            {
                {
                    action, new Genre
                    {
                        Name = action,
                        Title = action
                    }
                },
                {
                    adventure, new Genre
                    {
                        Name = adventure,
                        Title = adventure
                    }
                },
                {
                    comedy, new Genre
                    {
                        Name = comedy,
                        Title = comedy
                    }
                },
                {
                    ecchi, new Genre
                    {
                        Name = ecchi,
                        Title = ecchi
                    }
                },
                {
                    drama, new Genre
                    {
                        Name = drama,
                        Title = drama
                    }
                },
                {
                    detective, new Genre
                    {
                        Name = detective,
                        Title = detective
                    }
                },
                {
                    fantasy, new Genre
                    {
                        Name = fantasy,
                        Title = fantasy
                    }
                },
                {
                    game, new Genre
                    {
                        Name = game,
                        Title = game
                    }
                },
                {
                    harem, new Genre
                    {
                        Name = harem,
                        Title = harem
                    }
                },
                {
                    historical, new Genre
                    {
                        Name = historical,
                        Title = historical
                    }
                },
                {
                    horror, new Genre
                    {
                        Name = horror,
                        Title = horror
                    }
                },
                {
                    josei, new Genre
                    {
                        Name = josei,
                        Title = josei
                    }
                },
                {
                    magic, new Genre
                    {
                        Name = magic,
                        Title = magic
                    }
                },
                {
                    mecha, new Genre
                    {
                        Name = mecha,
                        Title = mecha
                    }
                },
                {
                    military, new Genre
                    {
                        Name = military,
                        Title = military
                    }
                },
                {
                    musical, new Genre
                    {
                        Name = musical,
                        Title = musical
                    }
                },
                {
                    mystery, new Genre
                    {
                        Name = mystery,
                        Title = mystery
                    }
                },
                {
                    parody, new Genre
                    {
                        Name = parody,
                        Title = parody
                    }
                },
                {
                    psychological, new Genre
                    {
                        Name = psychological,
                        Title = psychological
                    }
                },
                {
                    romance, new Genre
                    {
                        Name = romance,
                        Title = romance
                    }
                },
                {
                    schoolLife, new Genre
                    {
                        Name = schoolLife,
                        Title = schoolLife
                    }
                },
                {
                    sciFi, new Genre
                    {
                        Name = sciFi,
                        Title = sciFi
                    }
                },
                {
                    seinen, new Genre
                    {
                        Name = seinen,
                        Title = seinen
                    }
                },
                {
                    shoujo, new Genre
                    {
                        Name = shoujo,
                        Title = shoujo
                    }
                },
                {
                    shounen, new Genre
                    {
                        Name = shounen,
                        Title = shounen
                    }
                },
                {
                    sports, new Genre
                    {
                        Name = sports,
                        Title = sports
                    }
                },
                {
                    superNatural, new Genre
                    {
                        Name = superNatural,
                        Title = superNatural
                    }
                },
                {
                    superPower, new Genre
                    {
                        Name = superPower,
                        Title = superPower
                    }
                },
                {
                    tragedy, new Genre
                    {
                        Name = tragedy,
                        Title = tragedy
                    }
                },
                {
                    vampire, new Genre
                    {
                        Name = vampire,
                        Title = vampire
                    }
                }
            };

            #endregion

            #region movies

            var movies = new List<Movie>
            {
                new Movie
                {
                    Name = "Dragon Ball Super",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2017/01/08/[animevsub.com]-dragon-ball-chou_c4ebb2f874eef64c6b56562995bb365b.jpg",
                    Release = new DateTime(2015, 1, 1),
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[adventure]},
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[shounen]}
                    },
                    View = 20000,
                    Fansub = "SONGOKU Fanpage",
                    Description =
                        "Reuniting the franchise's iconic characters, Dragon Ball Super will follow the aftermath of Goku's fierce battle with Majin Buu as he attempts to maintain earth's fragile peace."
                },
                new Movie
                {
                    Name = "Naruto Shippuuden",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/10/21/[animevsub.com]-naruto-shippuuden_3dcdfccce91d66f7f7adb70114c228ee.jpg",
                    Release = new DateTime(2007, 1, 1),
                    View = 2100,
                    Status = MovieStatus.Completed,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[adventure]},
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[shounen]}
                    },
                    Description =
                        "Naruto: Shippuuden is the continuation of the original animated TV series Naruto.The story revolves around an older and slightly more matured Uzumaki Naruto and his quest to save his friend Uchiha Sasuke from the grips of the snake-like Shinobi, Orochimaru. After 2 and a half years Naruto finally returns to his village of Konoha, and sets about putting his ambitions to work, though it will not be easy, as he has amassed a few (more dangerous) enemies, in the likes of the shinobi organization; Akatsuki."
                },
                new Movie
                {
                    Name = "One Piece",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2015/02/14/[animevsub.com]-one-piece_da40893a4c0ed75459fd31e68b390148.jpg",
                    Release = new DateTime(2000, 1, 1),
                    View = 120001,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[adventure]},
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[shounen]},
                        new GenreMovie {Genre = genres[drama]},
                        new GenreMovie {Genre = genres[superPower]}
                    },
                    Description =
                        "One Piece xoay quanh 1 nhóm cướp biển được gọi là Băng Hải tặc Mũ Rơm - Straw Hat Pirates - được thành lập và lãnh đạo bởi thuyền trưởng Monkey D. Luffy. Cậu bé Luffy có ước mơ tìm thấy kho báu vĩ đại nhất. One Piece, của Vua Hải Tặc đời trước Gold D. Roger và trở thành Vua Hải Tặc đời kế tiếp."
                },
                new Movie
                {
                    Name = "Boruto: Naruto Next Gerenations",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2017/03/06/[animevsub.com]-boruto-naruto-next-generations-|-naruto-season-3_6629c0695f51f9502bd5048154f46ee8.jpg",
                    Release = new DateTime(2017, 1, 1),
                    View = 30200,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[adventure]},
                        new GenreMovie {Genre = genres[shounen]},
                        new GenreMovie {Genre = genres[superPower]}
                    },
                    Description =
                        "Naruto là một chàng trai trẻ đầy nhiệt huyết cũng như rất nghịch ngợm. Sau tất cả thì cậu cũng đã đạt được ước mơ của mình trở thành một Hokage vĩ đại nhất. Nhưng câu chuyện này không phải về Naruto, mà là câu chuyện về con trai của Naruto.... Chính là Boruto, thế hệ Ninja tiếp theo."
                },
                new Movie
                {
                    Name = "Koe No Katachi",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/11/05/[animevsub.com]-a-silent-voice,-the-shape-of-voice_c37cb87ed57d5e148f84cb7fa025bed4.jpg",
                    Release = new DateTime(2016, 1, 1),
                    View = 50050,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[drama]},
                        new GenreMovie {Genre = genres[schoolLife]},
                        new GenreMovie {Genre = genres[shounen]}
                    },
                    Description =
                        "Nishimiya Shouko, một cô bé bị điếc từ nhỏ, đã chuyển trường vào lớp của cậu bé Ishida Shouya. Để thỏa mãn sự tò mò của mình, cậu bé Shouya đã khơi mào trò bắt nạt Shouko vì tật khiếm thính. Trong một lần bắt nạt quá đà, Shouko đã bị chảy máu tai, và sau đó cô bé phải tiếp tục chuyển trường."
                },
                new Movie
                {
                    Name = "Kimi No Na Wa",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/09/13/[animevsub.com]-kimi-no-na-wa-_17b672c57668c1fb149d6b37a51e7d8d.jpg",
                    Release = new DateTime(2016, 1, 1),
                    View = 60200,
                    Status = MovieStatus.Completed,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[drama]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[schoolLife]},
                        new GenreMovie {Genre = genres[superNatural]}
                    },
                    Description =
                        "Câu chuyện về phép màu và tình yêu xoay xung quanh Mitsuha và Taki. Mitsuha là một cô bé học sinh cấp 3 sống tại một vùng nông thôn nằm rúc sâu trong núi. Cha cô là thị trưởng và rất ít khi ở nhà, bản thân cô sống với đứa em gái đang học tiểu học và bà nội."
                },
                new Movie
                {
                    Name = "Mahouka Koukou No Rettousei",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/12/27/[animevsub.com]-the-irregular-at-magic-high-school_3d4c311ff614980687780aea8a35bfe9.jpg",
                    Release = new DateTime(2014, 1, 1),
                    View = 13500,
                    Status = MovieStatus.Completed,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[magic]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[sciFi]},
                        new GenreMovie {Genre = genres[schoolLife]},
                        new GenreMovie {Genre = genres[superNatural]}
                    },
                    Description =
                        "Phép thuật không phải là sản phẩm của huyền thoại hay chuyện cổ tích, mà thay vào đó đã trở thành công nghệ thực tiễn từ một thời mà không ai biết được. Năng lực siêu nhiên đã trở thành một công nghệ được hệ thống hóa thông qua phép thuật, trong khi đó phép thuật thì đã trở thành một kỹ năng chuyên môn."
                },
                new Movie
                {
                    Name = "Akame Ga Kill",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/03/25/[animevsub.com]-akame-ga-kiru_6efb0d8d0bd0e5707185d2c15d043786.jpg",
                    Release = new DateTime(2014, 1, 1),
                    View = 22000,
                    Status = MovieStatus.Completed,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[adventure]},
                        new GenreMovie {Genre = genres[fantasy]},
                        new GenreMovie {Genre = genres[horror]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[shounen]},
                        new GenreMovie {Genre = genres[tragedy]}
                    },
                    Description =
                        "Tatsumi là một kiếm sĩ, đến thủ đô để tìm cách làm giàu cho ngôi làng nghèo khó của mình và trở thành nạn nhân của một vụ lừa tình lột tiền. Sau đó, cậu được một tiểu thư quý tộc tên là Aria cho tá túc. Đêm tiếp theo, nhóm sát thủ Night Raid do Akame chỉ huy tấn công vào tư dinh của Aria."
                },
                new Movie
                {
                    Name = "Detective Conan",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/04/18/[animevsub.com]-detective-conan_b96803c31fea61e705aa89184b092899.jpg",
                    Release = new DateTime(1996, 1, 1),
                    View = 1000220,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[detective]},
                        new GenreMovie {Genre = genres[schoolLife]}
                    },
                    Description =
                        "Mở đầu câu truyện, cậu học sinh trung học 17 tuổi Shinichi Kudo bị biến thành cậu bé Conan Edogawa. Shinichi trong phần đầu của Thám tử lừng danh Conan được miêu tả là một thám tử học đường xuất sắc. Trong một lần đi chơi công viên Miền Nhiệt đới với cô bạn từ thuở nhỏ Ran Mori, cậu tình cờ chứng kiến vụ một án giết người, Kishida - một hành khách trong trò chơi Chuyến tàu tốc hành đã bị giết một cách dã man. Cậu đã giúp cảnh sát làm sáng tỏ vụ án. "
                },
                new Movie
                {
                    Name = "Hyouka",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/04/07/[animevsub.com]-hyouka_b86eb1f91fde9a01f685e394da0d4881.jpg",
                    Release = new DateTime(2013, 1, 1),
                    View = 15003,
                    Status = MovieStatus.Completed,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[detective]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[schoolLife]}
                    },
                    Description =
                        "Câu chuyện xoay quanh Houtarou, người có cách sống khá xa cách và thờ ơ, luôn tìm cách để tiết kiệm năng lượng hết mức có thể. Cậu bị chị mình ép phải gia nhập câu lạc bộ văn học. Tại đó, cậu đã cùng những người bạn của mình tìm thấy một tuyển tập có tên là Hyouka, và đến gần hơn với những bí ẩn 33 năm trước."
                },
                new Movie
                {
                    Name = "Overlord",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/12/27/[animevsub.com]-overlord_f26f7cef18bbb70d2bdd51241da47ca0.jpg",
                    Release = new DateTime(2015, 1, 1),
                    View = 20402,
                    Status = MovieStatus.Completed,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[adventure]},
                        new GenreMovie {Genre = genres[fantasy]},
                        new GenreMovie {Genre = genres[game]},
                        new GenreMovie {Genre = genres[superNatural]}
                    },
                    Description =
                        "Câu chuyện bắt đầu trong những giây phút cuối tại tại Yggdrasil, một game online đình đám sắp phải đóng cửa. Nhân vật chính Momonga của chúng ta quyết định ở lại đến tận những phút cuối cùng với trò chơi yêu thích của mình và chờ server down. Bất ngờ, server không shutdown và Momonga bị mắc kẹt trong nhân vật của chính mình và xuyên việt tới thế giới khác."
                },
                new Movie
                {
                    Name = "Sword Art Online",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/03/29/[animevsub.com]-sword-art-online-ss1-sao_53499921e4745616974d92d0fed44eb9.jpg",
                    Release = new DateTime(2012, 1, 1),
                    View = 50300,
                    Status = MovieStatus.Completed,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[adventure]},
                        new GenreMovie {Genre = genres[fantasy]},
                        new GenreMovie {Genre = genres[game]},
                        new GenreMovie {Genre = genres[harem]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[sciFi]},
                        new GenreMovie {Genre = genres[superNatural]}
                    },
                    Description =
                        "Năm 2022 thế hệ game chạy trên NERvGear tiếp theo đã được công bố người dùng có thể kết nối với thế giới ảo thông qua chức năng FullDive. Sword Art Online - dòng game VRMMORPG chính thống đầu tiên trên nền NERvGear đã gây xôn xao trên toàn thế giới. Một trong số rất nhiều người chơi. Kirito quyết tâm chinh phục trò chơi này. Thế nhưng người sáng tạo ra SAO, Akihiko Kayaba lại thông báo rằng một khi đã tham gia thì không người chơi nào có thể thoát ra ngoài cho đến khi phá đảo."
                },
                new Movie
                {
                    Name = "Sword Art Online II : Phantom Bullet",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/04/15/[animevsub.com]-sword-art-online-ss2-sao-2_91782ddccbaad23fbb0c9bb3f838808f.jpg",
                    Release = new DateTime(2014, 1, 1),
                    View = 62000,
                    Status = MovieStatus.Completed,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[adventure]},
                        new GenreMovie {Genre = genres[fantasy]},
                        new GenreMovie {Genre = genres[game]},
                        new GenreMovie {Genre = genres[harem]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[sciFi]},
                        new GenreMovie {Genre = genres[superNatural]}
                    },
                    Description =
                        "Một năm sau khi phá đảo Sword Art Online (SAO), Kirito đã được Kikuoka mời khám phá thử Gun Gale Online, mà cụ thể là Death Gun, một vũ khí dường như là liên kết những cái chết trong thế giới thực tế ảo và thế giới thật. Khi vào game, Kirito gặp Sinon, người hướng dẫn cậu cách chơi (cày cuốc, sắm đồ, PK này nọ). Dần dần Kirito phát hiện ra những cái chết bí ẩn đều có liên quan đến một Guild có tên là Laughing Coffin trong SAO ngày xưa."
                },
                new Movie
                {
                    Name = "Shigatsu Wa Kimi No Uso",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/04/26/[animevsub.com]-[bd]-thang-tu-la-loi-noi-doi-cua-em_f103acafb0054772777a9447b95fd531.jpg",
                    Release = new DateTime(2014, 1, 1),
                    View = 5000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[drama]},
                        new GenreMovie {Genre = genres[musical]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[schoolLife]},
                        new GenreMovie {Genre = genres[shounen]}
                    },
                    Description =
                        "Câu chuyện kể về Arima Kosei, một thần đồng piano. Nhưng kể từ sau chấn động tâm lí do cái sự qua đời của mẹ cậu, Kosei đã không thể nghe thấy bất kì âm thanh nào. Cứ tưởng là cậu sẽ không bao giờ động vào những phím piano nữa nhưng đó là trước khi cậu đã gặp Miyazono Kawori..."
                },
                new Movie
                {
                    Name = "Kyoukai No Kanata",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/10/22/[animevsub.com]-beyond-the-boundary_d7b49a78b5d6b2a664a1a61659d3e55f.jpg",
                    Release = new DateTime(2013, 1, 1),
                    View = 2000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[fantasy]},
                        new GenreMovie {Genre = genres[schoolLife]},
                        new GenreMovie {Genre = genres[superNatural]}
                    },
                    Description =
                        "Trung tâm câu chuyện là một học sinh năm 2 trung học tên là Akihito Kanbara. Dù mang hình dáng con người, nhưng cậu lại mang trong mình dòng máu của quỷ nên sẽ không bao giờ bị thương tích vì có khả năng hồi phục nhanh chóng. Một ngày nọ, Akihito tình cờ làm quen với Mirai Kuriyama-một cô bé năm nhất-vì tưởng cô bé định… nhảy lầu. Mirai bị cô lập bởi khả năng điều khiển máu của mình, một quyền năng đặc biệt trong thế giới của cô. Nhiều sự việc bất thường bắt đầu diễn ra sau khi Akihito cứu Mirai."
                },
                new Movie
                {
                    Name = "Accel World",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/09/26/[animevsub.com]-[bd]-accel-world_d9e862e5d3aeb04dda6da4a1d5784347.jpg",
                    Release = new DateTime(2012, 1, 1),
                    View = 2000,
                    Status = MovieStatus.Completed,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[fantasy]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[schoolLife]},
                        new GenreMovie {Genre = genres[sciFi]},
                        new GenreMovie {Genre = genres[superNatural]}
                    },
                    Description =
                        "Được chuyển thể dựa trên light novel cùng tên của tác giả Kawahara Reki. Bối cảnh diễn ra vào năm 2046. Cậu Haruyuki Arita cảm thấy mình luôn bị xã hội hắt hủi. Tủi thân với thực tại, cậu đi tìm cảm giác hơn người trong thế giới game ảo. Tất cả đã thay đổi khi cậu gặp Kuroyuki Hime, cô gái nổi tiếng nhất của trường. Cậu nhận được từ cô 1 phần mềm cho phép cậu bước vào thế giới ảo Accel World. Tại đây Haruyuki trở thành Burst Linker một hiệp sĩ bảo vệ công chúa.."
                },
                new Movie
                {
                    Name = "Tonari No Totoro",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://cdn.myanimelist.net/images/anime/12/42085.jpg",
                    Release = new DateTime(1988, 1, 1),
                    View = 2000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[adventure]},
                        new GenreMovie {Genre = genres[comedy]}
                    },
                    Description =
                        "Bộ phim kể về cuộc sống của hai chị em Satsuki và Mei sau khi cùng bố chuyển về vùng nông thôn. Ngôi nhà này gần nơi bệnh viện mẹ hai cô bé đang nằm và để sau này khi mẹ chúng ra viện sẽ có môi trường sống tốt hơn. Hai chị em nghịch ngợm và tò mò về ngôi nhà mới, ngôi nhà thật kì lạ bởi có con gì đó màu đen, rất, rất nhiều đang ẩn náu đâu đấy; có những hạt mầm xinh xinh tự ở đâu rơi xuống đất. Gần ngôi nhà có một khu rừng lớn và một cây cổ thụ rất to, nhưng chưa bao giờ hai đứa được đặt chân đến cũng bởi vì sợ."
                },
                new Movie
                {
                    Name = "Hauru No Ugoku Shiro",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/08/29/[animevsub.com]-howl-s-moving-castle_f45acdf56a66c20ef50f202021ce076d.jpg",
                    Release = new DateTime(2004, 1, 1),
                    View = 2000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[adventure]},
                        new GenreMovie {Genre = genres[magic]}
                    },
                    Description =
                        "Sophie, một cô gái trầm tính làm việc tại một cửa hàng mũ, thấy cuộc sống của mình biến đổi khi cô phải lòng một phù thủy điển trai và bí ẩn tên Howl. Phù thủy Hoang mạc, ghen tức với mối quan hệ của họ, đã yểm thần chú lên Sophie. Trong cuộc hành trình thay đổi cuộc đời, Sophie đã bước lên tòa lâu đài bay kì diệu của Howl, bước vào một thế giới huyền diệu nhằm phá bỏ thần chú."
                },
                new Movie
                {
                    Name = "No Game No Life",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/10/01/[animevsub.com]-no-game-no-life_ea75f300da9764906399044006db69f5.jpg",
                    Release = new DateTime(2014, 1, 1),
                    View = 200230,
                    Status = MovieStatus.Completed,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[adventure]},
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[ecchi]},
                        new GenreMovie {Genre = genres[fantasy]},
                        new GenreMovie {Genre = genres[game]},
                        new GenreMovie {Genre = genres[superNatural]}
                    },
                    Description =
                        "2 anh em Sora và Shiro là người đã tạo ra [ ], một huyền thoại của thế giới ảo, một gamer được mệnh danh là bất khả chiến bại. Nhưng đằng sau hào quang trong thế giới ảo, 2 anh em họ lại là những NEET, những người vô dụng của xã hội. Một ngày nọ họ được một người tự xưng là Chúa đưa tới một thế giới của ông ta, thế giới Board World, nơi mà mọi thứ đều được quyết định bằng các trò chơi, từ tính mạng con người cho đến biên giới quốc gia."
                },
                new Movie
                {
                    Name = "Kill La Kill",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/05/14/[animevsub.com]-kill-la-kill_8e25380724f5e2de4aa9bd9e628bdd12.jpg",
                    Release = new DateTime(2014, 1, 1),
                    View = 5000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[ecchi]},
                        new GenreMovie {Genre = genres[schoolLife]}
                    },
                    Description =
                        "Câu chuyện đẫm máu xảy ra tại một trường trung học luôn sống trong sợ hãi, là nơi được cai trị bởi hội học sinh đáng sợ, dẫn đầu là chủ tịch hội đồng sinh viên Satsuki Kiryuin chuyên sử dụng vũ lực để đè bẹp bất cứ ai trong trường. Ryuuko Matoi đã đứng lên chống lại Satsuki, đồng thời mục đích của cô là tìm ra kẻ đã giết cha mình. Thế nhưng, để không chỉ có Satsuki, Ryuuko còn phải đối đầu với 4 vị vua của hội học sinh."
                },
                new Movie
                {
                    Name = "Ao No Exorcist",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/09/29/[animevsub.com]-ao-no-exorcist_65ca9233a2f79265b02e30a7c8e10c21.jpg",
                    Release = new DateTime(2011, 1, 1),
                    View = 40200,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[fantasy]},
                        new GenreMovie {Genre = genres[shounen]},
                        new GenreMovie {Genre = genres[superNatural]}
                    },
                    Description =
                        "Thế giới tồn tại hai thế giới song song. Một là thế giới con người, Assiah. Một là thế giới ác quỷ, Gehenna. Hai thế giới cơ bản không thể thông với nhau. Tuy nhiên, loài quỷ có thể tới Assiah bằng cách chiếm hữu thể xác con người. Nhưng không có thể xác nào có thể chứa được chúa tể ác quỷ, Satan.Rin Okumura, con trai của cha Satan và mẹ là con người, được tạo ra nhằm mục đích giúp Satan tồn tại ở Assiah. Cha nuôi của Rin đã hy sinh để cứu cậu thoát khỏi quỷ dữ. Và để trả thù cho cha nuôi, cũng như để khẳng định bản thân mình, Rin đã quyết định đi theo con đường pháp sư trừ ma..."
                },
                new Movie
                {
                    Name = "Joker Game",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/09/27/[animevsub.com]-joker-game_45a0ec6f97f5277e40147de4e9a35188.jpg",
                    Release = new DateTime(2016, 1, 1),
                    View = 4002,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[military]},
                        new GenreMovie {Genre = genres[seinen]}
                    },
                    Description =
                        "Lấy bối cảnh trong tthế chiến thứ hai, năm 1937, câu chuyện kể về một tổ chức đào tạo điệp viên bí mật với tên gọi “văn phòng D”. Tổ chức này đuợc thành lập bởi trung tá Yuuki trực thuộc quân đội quốc gia Nhật Bản. Ý tuởng của ông là tập hợp các tân binh tốt nghiệp từ các học viện quân đội và các quân dân, để đào tạo họ thành các điệp viên chuyên nghiệp. Những điệp viên này đuợc tập hợp thành một nhóm để thực hiện các nhiệm vụ đặc biệt. Jorou Gamou a.k.a nhân vật phản diện, cũng là một điệp viên, với sứ mệnh cao cả nhưng vất vả là tự lực cánh sinh truy tìm tài liệu mật “the black note” a.k.a sổ đen."
                },
                new Movie
                {
                    Name = "Tokyo Ghoul",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/10/01/[animevsub.com]-tokyo-ghoul_bbf45160e4a1ee3581ab6ad10ebfda6b.jpg",
                    Release = new DateTime(2014, 1, 1),
                    View = 4019,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[adventure]},
                        new GenreMovie {Genre = genres[drama]},
                        new GenreMovie {Genre = genres[fantasy]},
                        new GenreMovie {Genre = genres[horror]},
                        new GenreMovie {Genre = genres[psychological]},
                        new GenreMovie {Genre = genres[superNatural]},
                        new GenreMovie {Genre = genres[superPower]},
                        new GenreMovie {Genre = genres[mystery]}
                    },
                    Description =
                        "Đây là một bộ phim thuộc thể loại kinh dị với đồ họa mang tính chất bóng tối và được diễn ra tại thành phố Tokyo, nơi mọi người bị ám ảnh bởi những thứ gọi là Ghoul bởi vì chúng chuyên đi ăn tươi nuốt sống con người. Mọi người luôn phải sống trong lo sợ bởi những con Ghoul đeo mặt nạ bí ẩn. Một cậu sinh viên đại học Kaneki đã gặp một cô gái tên là Rize tại quán cafe mà cậu ta thường hay lui tới và cô gái đó có cùng sở thích đọc sách giống cậu...."
                },
                new Movie
                {
                    Name = "Tokyo Ghoul season 2",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://cdn.myanimelist.net/images/anime/13/71777.jpg",
                    Release = new DateTime(2015, 1, 1),
                    View = 4000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[adventure]},
                        new GenreMovie {Genre = genres[drama]},
                        new GenreMovie {Genre = genres[fantasy]},
                        new GenreMovie {Genre = genres[horror]},
                        new GenreMovie {Genre = genres[psychological]},
                        new GenreMovie {Genre = genres[superNatural]},
                        new GenreMovie {Genre = genres[superPower]},
                        new GenreMovie {Genre = genres[mystery]}
                    },
                    Description =
                        "Phim là một câu chuyện mang bầu sắc u tối của thành phố Tokyo, nơi xảy ra hàng loạt các vụ án mạng được gây ra bởi các con quỷ đội lốt con người. Main chính nhà ta là sinh viên đại học tên Kaneki gặp gỡ được em Rize, do 2 người có cùng sở thích nên đã phải lòng nhau. Vào buổi tối hôm hẹn hò, em và ảnh cùng nhau đi vào một con phố hẻo rồi cuộc đời anh main thay đổi ngay trong đêm hôm đó."
                },
                new Movie
                {
                    Name = "Bleach",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://i.imgur.com/DSko8fI.jpg",
                    Release = new DateTime(2004, 1, 1),
                    View = 4000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[shounen]},
                        new GenreMovie {Genre = genres[superNatural]},
                        new GenreMovie {Genre = genres[superPower]}
                    },
                    Description =
                        "Ichigo Kurosaki là một thiếu niên có khả năng nhìn thấy linh hồn. Cuộc sống của anh thay đổi nhanh chóng bởi sự xuất hiện đột ngột của một Soul Reaper-một trong những người điều chỉnh dòng chảy của linh hồn giữa thế giới con người và thế giới bên kia, tên là Kuchiki Rukia, người đến thế giới con người để tìm diệt Hollow, một linh hồn lạc lối rất nguy hiểm."
                },
                new Movie
                {
                    Name = "Attack On Titan",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/04/16/[animevsub.com]-attack-on-titan_b8b8988fd812bb8e0c86a06ee7bb4053.jpg",
                    Release = new DateTime(2013, 1, 1),
                    View = 14000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[adventure]},
                        new GenreMovie {Genre = genres[drama]},
                        new GenreMovie {Genre = genres[fantasy]},
                        new GenreMovie {Genre = genres[horror]},
                        new GenreMovie {Genre = genres[superNatural]},
                        new GenreMovie {Genre = genres[superPower]}
                    },
                    Description =
                        "Eren Jaeger sống trong một thành phố bao bọc bởi tường đá. Titan giết người ở ngoài đó. Trong nhiều thập kỉ, thành viên của Nhóm trinh thám Legion là những con người duy nhất dám bước ra khỏi bức tường và thu thập thông tin về những Titan. Eren, một người yêu hòa bình, không còn nguyện vọng nào to lớn việc gia nhập họ."
                },
                new Movie
                {
                    Name = "5 Centimeters Per Second",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://cdn.myanimelist.net/images/anime/6/73426.jpg",
                    Release = new DateTime(2007, 1, 1),
                    View = 4000,
                    Status = MovieStatus.Completed,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[drama]},
                        new GenreMovie {Genre = genres[romance]}
                    },
                    Description =
                        "Đây là một câu chuyện tình buồn diễn ra tại Nhật Bản, với xuất phát điểm là từ những năm 90 khi Takaki Tono mới 13 tuổi cho tới hiện tại khi anh đã đi làm. Film gồm 3 chương nhỏ gộp lại dài 62 phút: 1. Oukashou (The Chosen Cherry Blossoms), 2. Cosmonaut và 3. Byousoku 5 Centimeter (5 Centimeters per Second). Chương một mở đầu câu chuyện bằng một lời hứa trẻ con, đã dẫn dắt cả người xem lần lượt đi qua 3 quãng thời gian quan trọng trong cuộc đời Takaki Tono và đều liên quan tới tình yêu của anh dành cho một người con gái."
                },
                new Movie
                {
                    Name = "Monster Musume No Iru Nichijou Special !",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://cdn.myanimelist.net/images/anime/9/74970.jpg",
                    Release = new DateTime(2015, 1, 1),
                    View = 4000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[ecchi]},
                        new GenreMovie {Genre = genres[harem]}
                    },
                    Description =
                        "Thế giới biết được có các loài nửa người nửa thú và đặt ra Bộ Luật Giao Lưu Văn Hóa giữa các loại, anh main nhà ta chả hiểu sao bị chính phủ đưa nhầm một em Lamia nửa người nửa rắn đến, và tiếp theo đó là nhiều em các loài khác nữa."
                },
                new Movie
                {
                    Name = "Prison School",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/09/27/[animevsub.com]-prison-school-bd_df0b9179626c9d67c3e2480c701177c3.jpg",
                    Release = new DateTime(2015, 1, 1),
                    View = 4000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[ecchi]},
                        new GenreMovie {Genre = genres[horror]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[schoolLife]},
                        new GenreMovie {Genre = genres[seinen]},
                        new GenreMovie {Genre = genres[tragedy]}
                    },
                    Description =
                        "Bạn đã từng đọc các bộ truyện về High School---- Học viện tư thục Hachimitsu ở Tokyo đó giờ là một trường học danh giá chỉ dành riêng cho con gái. Nhưng mà “lại” nhờ ơn cái chính sách nào đó của bộ giáo dục mà giờ đây nam sinh có thể nhập học vô trường này. Nghe tin “lành” thì tất nhiên là sẽ có những thanh niên tiên phong đăng ký vào trường rồi..."
                },
                new Movie
                {
                    Name = "High School DxD",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/09/26/[animevsub.com]-high-school-dxd_78bb9878a117107408aaba1887a9ff14.jpg",
                    Release = new DateTime(2012, 1, 1),
                    View = 4000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[ecchi]},
                        new GenreMovie {Genre = genres[harem]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[schoolLife]},
                        new GenreMovie {Genre = genres[shounen]}
                    },
                    Description =
                        "Câu chuyện bắt đầu với anh main tên là Hyoudou Issei, một thằng đực rựa trẻ người còn non dạ hay không thì vẫn chưa biết. Anh main này có tình sử khá là hào hùng với số tuổi bằng số năm chưa có bạn gái. Một ngày đẹp trời, ý nhầm, một đêm đẹp trời, Cô Bạn Gái Xinh Đẹp Quyến Rũ Ku Te Amano Yuuma bỗng rủ cậu đến một nơi vắng vẻ và thỉnh cầu cậu một điều hết sức dễ thương: Cậu có thể tắt hơi thở ngay bây giờ được không ?.Hôm sau cậu tỉnh dậy và phát hiện mình vẫn chưa đi ngắm gà. Giấc mơ ? Có thể vậy, cũng có thể là không. Chỉ có một điều là chắc chắn: Từ đó về sau, cuộc đời cậu hoàn toàn bẻ sang một hướng khác..."
                },
                new Movie
                {
                    Name = "High School DxD season 2",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/03/23/[animevsub.com]-high-school-dxd-new-bd_ebdf4cabea92577f8c82c5a11f5650ff.jpg",
                    Release = new DateTime(2014, 1, 1),
                    View = 4000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[ecchi]},
                        new GenreMovie {Genre = genres[harem]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[schoolLife]},
                        new GenreMovie {Genre = genres[shounen]}
                    },
                    Description =
                        "Tiếp tục cuộc chiến giành lại vị trí bá vương cho gia tộc của Rias đang dở dang ở phần 1. Hyoudou Issei đã trở lại một lần nữa lợi hại gấp đôi ecchi gấp bội trong Season thứ hai của bộ anime High School DxD chuyện gì sẽ xảy ra với con Oppai Dragon này mọi người hãy cùng theo dõi."
                },
                new Movie
                {
                    Name = "High School DxD BorN season 3",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img1.ak.crunchyroll.com/i/spire1/a33f57842c2a7bf94ef5c5236f6c98a41421732007_full.jpg",
                    Release = new DateTime(2015, 1, 1),
                    View = 4000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[ecchi]},
                        new GenreMovie {Genre = genres[harem]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[schoolLife]},
                        new GenreMovie {Genre = genres[shounen]}
                    },
                    Description =
                        "Bộ anime High School DxD BorN là phần thứ 3 của bộ High School DxD"
                },
                new Movie
                {
                    Name = "Dagashi Kashi",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2017/01/01/[animevsub.com]-dagashikashi_7b3b7c3723dbc14d276e0b12e9049af0.jpg",
                    Release = new DateTime(2016, 1, 1),
                    View = 4000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[shounen]}
                    },
                    Description =
                        "Cha của Shikada Kokonotsu làm chủ một cửa hàng bánh kẹo ở vùng quê, và kế hoạch của ông là để cho Kokonotsu kế thừa nó vào một ngày không xa. Tuy nhiên, thay vì theo ý ông, Kokonotsu lại muốn thành một mangaka. Một ngày mùa hè, cô gái nhìn đáng yêu nhưng lại có vẻ kỳ quái Shidare Hotaru, từ công ty đồ ngọt nổi tiếng đến thăm nơi đây. Cha của Kokonotsu nổi tiếng nên lẽ dĩ nhiên cô ta muốn ông vào công ty của gia đình. Tuy vậy, ông chỉ đồng ý nếu cô ấy có thể thuyết phục Kokonotsu nối nghiệp kinh doanh của gia đình!"
                },
                new Movie
                {
                    Name = "Fairy Tail season 1",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/04/16/[animevsub.com]-fairy-tail-hoi-phap-su_6643833d1725d659d94dd680cf6b10f0.jpg",
                    Release = new DateTime(2009, 1, 1),
                    View = 410030,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[adventure]},
                        new GenreMovie {Genre = genres[fantasy]},
                        new GenreMovie {Genre = genres[magic]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[schoolLife]},
                        new GenreMovie {Genre = genres[shounen]},
                        new GenreMovie {Genre = genres[superNatural]}
                    },
                    Description =
                        "Fairy Tail nói về Lucy là 1 cô gái trẻ 17 tuổi, với mong ước trở thành một pháp sư đầy quyền năng. Trên đường phiêu lưu thực hiện ước mơ, Lucy tình cờ gặp được một bộ đôi quái gở - Natsu và Happy, đang trên đường tìm kiếm Hỏa Long Igneel - tại Thị trấn Hargeon. Ước mơ của Lucy là được tham gia vào Bang hội Fairy Tail, nơi tập trung đầy pháp sư tài giỏi. Và vì mong muốn được gia nhập, cô đã mắc bẫy của tên tự xưng là Salamander (Hỏa Long) của Fairy Tail. Đúng lúc đó thì Natsu xuất hiện giúp đỡ Lucy.."
                },
                new Movie
                {
                    Name = "Fairy Tail season 2",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/10/01/[animevsub.com]-fairy-tail-2014-fairy-tail-season-2_91084252e1d82d84aaae2b5449017713.jpg",
                    Release = new DateTime(2014, 1, 1),
                    View = 43000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[adventure]},
                        new GenreMovie {Genre = genres[fantasy]},
                        new GenreMovie {Genre = genres[magic]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[schoolLife]},
                        new GenreMovie {Genre = genres[shounen]},
                        new GenreMovie {Genre = genres[superNatural]}
                    },
                    Description =
                        "Câu chuyện về một cô thiếu nữ tên Lucy Heartfilia, khao khát của cô là gia nhập Hội Pháp sư nổi tiếng Fairy Tail. Trên đường phiêu lưu, Lucy đã vô tình gặp gỡ Natsu Salamander Dragneel, một thành viên của Fairy Tail, người sở hữu pháp thuật cổ đại Sát Long. Thế rồi Lucy được Natsu giới thiệu vào Hội Pháp sư Fairy Tail và cùng anh chàng này tham gia vô số nhiệm vụ khó khăn nhưng cũng không kém phần thú vị."
                },
                new Movie
                {
                    Name = "Date A Live season 1",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/09/26/[animevsub.com]-date-a-live_562d39420954f5d620737844115e1623.jpg",
                    Release = new DateTime(2013, 1, 1),
                    View = 4000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[ecchi]},
                        new GenreMovie {Genre = genres[harem]},
                        new GenreMovie {Genre = genres[mecha]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[schoolLife]}
                    },
                    Description =
                        "Xoay quanh học sinh nam tên Itsuka Shidou, người đã gặp một cô gái tinh linh đến từ một thế giới đã bị phá hủy, người đã gây nên nhiều cơn chấn động thời không.Và chàng trai phải ngăn chặn cô gái bằng cách hẹn hò với cô ta."
                },
                new Movie
                {
                    Name = "Date A Live season 2",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/10/01/[animevsub.com]-date-a-live-ss2_53f74497d62ba8f6030e91f054d3daf6.jpg",
                    Release = new DateTime(2014, 1, 1),
                    View = 4000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[ecchi]},
                        new GenreMovie {Genre = genres[harem]},
                        new GenreMovie {Genre = genres[mecha]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[schoolLife]}
                    },
                    Description =
                        "Date A Live II tiếp tục câu chuyện của chàng trai Shido Itsuka. 30 năm trước, một hiện tượng kỳ lạ được gọi là spacequake đã tàn phá trung tâm của đại lục Á-Âu, đe dọa mạng sống của ít nhất 150 triệu người và đã làm thế giới trở nên bất thường. Khi đó thì Shidou Itsuka là anh chàng có khả năng bí ẩn có thể phong ấn Tinh linh. Tuy nhiên, điều kiện để phong ấn là phải làm họ yêu cậu. Phần 2 sẽ xuất hiện thêm 3 Tinh linh mới, và lần này Shidou buộc phải cưa đổ cô nàng Miku...."
                },
                new Movie
                {
                    Name = "Black Bullet",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://cdn.myanimelist.net/images/anime/6/57947.jpg",
                    Release = new DateTime(2014, 1, 1),
                    View = 4000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[adventure]},
                        new GenreMovie {Genre = genres[fantasy]},
                        new GenreMovie {Genre = genres[harem]},
                        new GenreMovie {Genre = genres[mystery]},
                        new GenreMovie {Genre = genres[sciFi]},
                        new GenreMovie {Genre = genres[shounen]},
                        new GenreMovie {Genre = genres[tragedy]}
                    },
                    Description =
                        "Trong tương lai không xa, con người phải đối mặt với một loại vi-rút bí ẩn tên là Gastrea, có khả năng lây lan nhanh và vô cùng nguy hiểm. Rintarou - học sinh trung học và cũng là thành viên của Civil Security, một tổ chức chuyên đào tạo kỹ năng chiến đấu chống vi-rút Gastrea, luôn can đảm nhận những nhiệm vụ nguy hiểm khó ai gánh vác nổi. Cộng sự của cậu tên là Enju, cùng nhau chiến đấu bằng các kỹ năng bùm chéo xoẹt xoẹt. Một ngày kia, họ nhận được một nhiệm vụ quan trọng từ chính phủ: ngăn chặn nguy cơ diệt vong của Tokyo... Trong chiến trường khốc liệt ấy, một câu chuyện về các anh hùng đầy hồi hộp và hấp dẫn lại bắt đầu..."
                },
                new Movie
                {
                    Name = "Nisekoi - False Love",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://cdn.myanimelist.net/images/anime/12/54337.jpg",
                    Release = new DateTime(2014, 1, 1),
                    View = 4000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[ecchi]},
                        new GenreMovie {Genre = genres[harem]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[schoolLife]},
                        new GenreMovie {Genre = genres[shounen]}
                    },
                    Description =
                        "Nisekoi xoay quanh Raku Ichijo, cậu ấm lãnh đạo băng yakuza thuộc phe Shuei-Gumi và Chitoge Kirisaki, con gái của ông trùm băng đảng giang hồ Beehive khét tiếng. Raku Ichijo đã có 1 lời hứa bí mật với người yêu thời thơ ấu của mình, giữ một mặt dây chuyền như một vật lưu niệm và người yêu của cậu giữ lấy chiếc chìa khóa. Cậu mong rằng một ngày nào đó được gặp lại người yêu đó, nhiều năm sau, thực tế đập tan hy vọng của cậu khi Chitoge Kirisaki vô tình cho cậu ăn đầu gối vào mặt. "
                },
                new Movie
                {
                    Name = "Hotarubi No Mori E",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/03/26/[animevsub.com]-hotarubi-no-mori-e_79622a7601457487e319b7ad3bfd680c.jpg",
                    Release = new DateTime(2011, 1, 1),
                    View = 4000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[drama]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[shounen]},
                        new GenreMovie {Genre = genres[superNatural]}
                    },
                    Description =
                        "Hotarubi no Mori e kể về Hotaru, trong một lần cô bé đi lạc vào rừng thì gặp được Gin, một chàng trai trẻ kì lạ mà khi bị con người chạm vào thì cậu ta sẽ biến mất, Gin dẫn Hotaru rời khỏi khu rừng và câu chuyện bắt đầu từ đó..."
                },
                new Movie
                {
                    Name = "Angel Beats",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/09/26/[animevsub.com]-[bd]-angel-beats_ddf797c6446d6c0bca619b33f84196cd.jpg",
                    Release = new DateTime(2010, 1, 1),
                    View = 4000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[drama]},
                        new GenreMovie {Genre = genres[fantasy]},
                        new GenreMovie {Genre = genres[romance]}
                    },
                    Description =
                        "Trong thế giới cõi âm các thiên sứ chiến đấu cho tương lai và số phận của mình. Nhân vật chính là Yuri, người đứng đầu tổ chức Shinda Sekai Sensen (chiến tuyến thế giới cõi âm) chống lại thánh thần và những kẻ đã gán cho cô một cuộc sống vô nghĩa. Bên cạnh đó Tenshi vị nữ chủ tịch hội học sinh thế giới cõi âm, cũng lãnh đạo các Thiên sứ ngăn chặn cuộc bạo động của tổ chức Shinda Sekai Sensen."
                },
                new Movie
                {
                    Name = "Chuunibyou Demo Koi Ga Shitai",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://cdn.myanimelist.net/images/anime/12/46931.jpg",
                    Release = new DateTime(2012, 1, 1),
                    View = 90030,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[drama]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[schoolLife]}
                    },
                    Description =
                        "Togashi Yuuta là một cậu học sinh từng mắc hội chứng cấp 2 (chuunibyo), và Takanashi Rikka là một cô bạn hiện đang bị mắc hội chứng này. Cả hai đã lập giao ước với nhau để có những tháng ngày học sinh tuyệt vời nhất. Tuy nhiên, Shichimiya Satone, hay còn gọi là Sophia Ring SP Saturn VII, một người bạn hồi học cấp 2 bị nhiễm hội chứng nặng nhất đã xuất hiện, đảo lộn cuộc sống của Togashi. Và thế là cuộc chiến giữa Saturn và Tà vương chân nhãn bắt đầu."
                },
                new Movie
                {
                    Name = "Highschool Of The Dead",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/04/15/[animevsub.com]-highschool-of-the-dead-uncensor-[bd]_0c4f7166b2e9b46ef78aef94c7aecf43.jpg",
                    Release = new DateTime(2010, 1, 1),
                    View = 20300,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[ecchi]},
                        new GenreMovie {Genre = genres[horror]},
                        new GenreMovie {Genre = genres[superNatural]}
                    },
                    Description =
                        "Thế giới bị bao trùm bởi một căn bênh dịch chết người ,nó biến người ta trở thành xác chết biết đi. Tại Nhật một số học sinh và cô y tá trường trung học Fujimi cùng nhau vượt qua chiến đấu chống chọi với cơn dịch này."
                },
                new Movie
                {
                    Name = "Gintama",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/09/29/[animevsub.com]-gintama_1121094e7b1e3e26d600a78101dfd300.jpg",
                    Release = new DateTime(2006, 1, 1),
                    View = 12345,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[historical]},
                        new GenreMovie {Genre = genres[parody]},
                        new GenreMovie {Genre = genres[sciFi]},
                        new GenreMovie {Genre = genres[shounen]}
                    },
                    Description =
                        "Đất nước của những Samurai. Có một thời đất nước chúng tôi được gọi như vậy.20 năm trước…Những kẻ ngoài hành tinh tự xưng là Amanto đột ngột đổ bộ xuống và thiết lập lệnh cấm mang kiếm. Samurai giờ đây bị khinh rẻ, coi thường. Trong thời đại như thế, vẫn còn một người đầy tinh thần samurai. Tên anh ta là Sakata Gintoki. Và tôi, Shimura Shinpachi, cùng Kagura-chan vì một số việc đưa đẩy mà bắt đầu làm việc cho cái tên vô trách nhiệm, hảo ngọt đó tại Vạn Sự Ốc."
                },
                new Movie
                {
                    Name = "Ore Monogatari!!",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://i.imgur.com/fxqCyNc.jpg",
                    Release = new DateTime(2015, 1, 1),
                    View = 4123,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[shoujo]}
                    },
                    Description =
                        "Bộ anime vietsub Ore Monogatari được chuyển thể từ bộ manga cùng tên kể về anh chàng Gouda Takeo là một sinh viên năm nhất tại trường trung học. Anh ấy rất to con và cao 2m. Nói về anh chàng này với cô gái thời thơ ấu..."
                },
                new Movie
                {
                    Name = "Amagi Brilliant Park",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2017/02/20/[animevsub.com]-amaburi-bd-amagi-cong-vien-ruc-ro-bd_03e4c397fcfb34c8938d3deaf16c146a.jpg",
                    Release = new DateTime(2014, 1, 1),
                    View = 12351,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[magic]}
                    },
                    Description =
                        "Kanie Seiya, một cựu thiên tài mang cái tên Kodama Seiya, muốn sống một cuộc sống yên ổn, thì bỗng dưng bị một cô nàng cùng lớp mời đi công viên giải trí bằng cách dí một khẩu súng vào ngay mặt cậu. Đi hẹn hò cho đã xong, cậu bị một bé loli mời làm quản lý của cái công viên giải trí xập xệ này với mục tiêu là kiếm đủ 10 vạn khách trong thời hạn 2 tuần."
                },
                new Movie
                {
                    Name = "Magi: The Labyrinth Of Magic",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/04/16/[animevsub.com]-magi-the-labyrinth-of-magic_294b4b2b52a2624ad2ed632558bc0d58.jpg",
                    Release = new DateTime(2013, 1, 1),
                    View = 23121,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[adventure]},
                        new GenreMovie {Genre = genres[fantasy]},
                        new GenreMovie {Genre = genres[magic]},
                        new GenreMovie {Genre = genres[shounen]}
                    },
                    Description =
                        "Câu chuyện là một dòng chảy của số phận và cuộc chiến bảo vệ thế giới đi theo con đường lẽ phải. Aladin, nhân vật chính của bộ phim, đã đặt ra mục tiêu khám phá thế giới sau khi gần hết quãng đời mình bị mắc kẹt trong một căn phòng. Người bạn thân nhất của cậu ta là cây sáo và linh hồn của lửa mang tên Ugo."
                },
                new Movie
                {
                    Name = "Magi: The Kingdom Of Magic",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://cdn.myanimelist.net/images/anime/13/55039.jpg",
                    Release = new DateTime(2013, 1, 1),
                    View = 43423,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[adventure]},
                        new GenreMovie {Genre = genres[fantasy]},
                        new GenreMovie {Genre = genres[magic]},
                        new GenreMovie {Genre = genres[shounen]}
                    },
                    Description =
                        "Aladdin, Alibaba và Morgiana tiếp tục cuộc phiêu lưu ở vương quốc phép thuật Magnostadt. Một đất nước bị cai trị bởi các pháp sư và đế chế Reim hùng mạnh."
                },
                new Movie
                {
                    Name = "Isshuukan Friends",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://cdn.myanimelist.net/images/anime/6/61891.jpg",
                    Release = new DateTime(2014, 1, 1),
                    View = 65656,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[schoolLife]},
                        new GenreMovie {Genre = genres[shounen]}
                    },
                    Description =
                        "Đôi khi chả vì một lý do nào đó chúng ta để ý đến một người. Người đó chả cần có gì nổi bật nhưng ta vẫn để ý. Thật là khó để giải thích cảm giác đó...từ để ý rồi dần đến quan tâm và thích. Tưởng chừng một câu truyện đơn giản về học đường, về một đôi bạn trẻ sống một cuộc sống cấp 3 bình thường và sẽ kết thúc như bao câu truyện bình thường khác thì bất ngờ nó lại bất bình thường theo nhiều phương diện."
                },
                new Movie
                {
                    Name = "Inuyasha",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://cdn.myanimelist.net/images/anime/8/20483.jpg",
                    Release = new DateTime(2000, 1, 1),
                    View = 66546,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[adventure]},
                        new GenreMovie {Genre = genres[fantasy]},
                        new GenreMovie {Genre = genres[magic]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[shounen]},
                        new GenreMovie {Genre = genres[superNatural]},
                        new GenreMovie {Genre = genres[superPower]}
                    },
                    Description =
                        "Câu chuyện bắt đầu từ lúc Kagome, vào ngày sinh nhật thứ mười lăm, đã vô tình rơi xuống cái giếng cạn và trở về thời phong kiến của Nhật Bản vào 500 năm trước. Ở đây, cô đã gặp được Inu Yasha (và sau này là Shippou, Miroku, Sango và Kirara). Trong một lần vì cứu 1 đứa bé, cô vô tình đã làm vỡ viên Ngọc tứ hồn (Shikon no Tama) thành từng mảnh vụn. Vì thế, theo lời đề nghị của bà Kaede, Inu Yasha và Kagome đã cùng nhau hợp tác để thu thập lại các mảnh vỡ..."
                },
                new Movie
                {
                    Name = "Love Live - School Idol Project",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/09/26/[animevsub.com]-love-live-school-idol-project_ccbe338644265eaa7caf587f142e6445.jpg",
                    Release = new DateTime(2013, 1, 1),
                    View = 9884,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[musical]},
                        new GenreMovie {Genre = genres[schoolLife]}
                    },
                    Description =
                        "Love Live kể về Otonokizaka, ngôi trường cấp 3 hiện đang đứng trước nguy cơ bị đóng cửa do có ngày càng ít đơn xin vào nhập học. Trong bối cảnh đó, 9 nữ sinh đã quyết tâm lập nên một nhóm Idol nữ để gây tiếng vang, giúp trường thoát khỏi tình cảnh éo le này. Nói ngắn gọn thì đây là project về các bé nữ sinh trên con đường trở thành thần tượng..."
                },
                new Movie
                {
                    Name = "Fate/stay Night",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/04/22/[animevsub.com]-fate-stay-night_fe962b98704419366ccb328a14a19aa1.jpg",
                    Release = new DateTime(2006, 1, 1),
                    View = 67867,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[adventure]},
                        new GenreMovie {Genre = genres[fantasy]},
                        new GenreMovie {Genre = genres[magic]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[superPower]}
                    },
                    Description =
                        "Fate Stay Night xoay quanh Holy Grail War. Cuộc Chiến Giành Chén Thánh. Chén Thánh sẽ thực hiện điều ước của người chiến thắng cuộc chiến. Ở mỗi Holy Grail War bảy pháp sư được chọn sẽ triệu hồi cho mình một Servant và cùng nhau chiến đấu. Servant đều là những anh hùng trong truyền thuyết được triệu tập đến thế giới này theo 7 class : Saber, Archer, Lancer, Berserker, Caster, Assasin và Rider."
                },
                new Movie
                {
                    Name = "Death Note",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2017/01/25/[animevsub.com]-death-note-bluray_dc74169216bfdf187f3243b471163ff5.jpg",
                    Release = new DateTime(2007, 1, 1),
                    View = 657561,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[detective]},
                        new GenreMovie {Genre = genres[mystery]},
                        new GenreMovie {Genre = genres[psychological]},
                        new GenreMovie {Genre = genres[superNatural]}
                    },
                    Description =
                        "Một thần chết tên Ryuuku cố tình đánh rơi quyển sổ Death Note xuống thế giới loài người với mong muốn rằng hắn sẽ tìm được một thú vui nào đó từ việc này. Một học sinh trung học tên Yagami Light (hay Yagami Raito) là người nhặt được quyển sổ này và vì thế mà có khả năng giết bất cứ người nào chỉ bằng cách cách viết tên người đó vào quyển sổ và tưởng tượng ra khuôn mặt họ khi viết. Cậu quyết định dùng Death Note để tiêu diệt những kẻ tội phạm và những kẻ giết người tàn ác thông qua cuốn sổ."
                },
                new Movie
                {
                    Name = "D-frag!",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://cdn.myanimelist.net/images/anime/2/53407.jpg",
                    Release = new DateTime(2014, 1, 1),
                    View = 6654,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[schoolLife]}
                    },
                    Description =
                        "Chuyển thể từ bộ manga cùng tên. Một thằng bựa, tên Kazama Kenji, đang có một cuộc sống oanh liệt của một đầu gấu, thì bỗng dưng bị dính bẫy của 4 cô nàng não phẳng + 1 bà giáo viên đầu to óc trái nho. Hệ quả là cậu phải vào cái clb chuyên ăn không ngồi rồi. Thế là một chuỗi sự kiện hài trong mơ bắt đầu xảy đến với cậu."
                },
                new Movie
                {
                    Name = "Spirited Away - Vùng Đất Linh Hồn",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://upload.wikimedia.org/wikipedia/az/thumb/8/8c/Ruhlarla_sovrulanlar_(animasiya,_2001).jpg/230px-Ruhlarla_sovrulanlar_(animasiya,_2001).jpg",
                    Release = new DateTime(2001, 1, 1),
                    View = 1,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[adventure]},
                        new GenreMovie {Genre = genres[superNatural]}
                    },
                    Description =
                        "Chuyện phim kể về cuộc phiêu lưu kì lạ của cô bé 10 tuổi Chihiro Ogino. Gia đình Chihiro chuyển nhà lên vùng thôn quê. Điều này khiến cho cô bé rất khó chịu và buồn phiền, bởi cô phải xa bạn bè tại trường cũ. Trên đường đến nhà mới, bố của Chihiro nhầm một con đường lạ là lối đi tắt nên lái xe vào đó. Con đường gập ghềnh đưa gia đình Chihiro tiến sâu vào rừng. Cuối cùng, chiếc xe của họ dừng lại trước một cánh cổng màu đỏ cũ kĩ, bảng tên rỉ sét đến nỗi không đọc được nữa. Bố mẹ Chihiro quyết định đi vào trong xem thử dù cô bé năn nỉ họ đừng vào. "
                },
                new Movie
                {
                    Name = "Cardcaptor Sakura",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=https://lh5.googleusercontent.com/-qeuQ6CbtQ8Q/VIAG9rGaj6I/AAAAAAAAZfs/m9lrEITJgCI/s307/14516.jpg",
                    Release = new DateTime(2000, 1, 1),
                    View = 424,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[adventure]},
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[drama]},
                        new GenreMovie {Genre = genres[fantasy]},
                        new GenreMovie {Genre = genres[magic]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[schoolLife]},
                        new GenreMovie {Genre = genres[shoujo]},
                        new GenreMovie {Genre = genres[superNatural]},
                        new GenreMovie {Genre = genres[superPower]}
                    },
                    Description =
                        "Câu chuyện xoay quanh Kinomoto Sakura, một học sinh tiểu học tình cờ phát hiện ra mình đang nắm giữ một sức mạnh kì diệu sau khi vô tình giải phóng một bộ thẻ bài ma thuật đã được niêm phong nhiều năm trong một quyển sách. Sau đó cô được giao nhiệm vụ phải thu phục lại tất cả các thẻ bài đã chạy thoát nhằm ngăn chặn chúng phá hủy thế giới."
                },
                new Movie
                {
                    Name = "Himouto! Umaru-chan",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/09/17/[animevsub.com]-my-two-faced-little-sister_f08d6fe9814cc2353763b70b0b3220f6.jpg",
                    Release = new DateTime(2015, 1, 1),
                    View = 884,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[schoolLife]}
                    },
                    Description =
                        "Nói về một cô gái 16 tuổi sống chung với anh cô ấy là Taihei. Cô ấy là một người em gái hoàn hảo với một tấm lòng nhân hậu, thông minh và sự nổi tiếng, mọi người đều ngưỡng mộ.Tuy nhiên, Himouto (cô em gái xinh đẹp) có một bí mật không thể để người ngoài khám phá…"
                },
                new Movie
                {
                    Name = "Hotaru No Haka",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://cdn.myanimelist.net/images/anime/4/42067.jpg",
                    Release = new DateTime(1988, 1, 1),
                    View = 1234,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[drama]},
                        new GenreMovie {Genre = genres[historical]}
                    },
                    Description =
                        "Được đặt trong bối cảnh giai đoạn cuối của Chiến tranh thế giới 2 ở Nhật Bản, bộ phim kể lại câu chuyện chua xót nhưng cảm động về tình anh em của hai đứa trẻ mồ côi Seita và em gái của cậu Setsuko. Hai anh em mất mẹ sau cuộc thả bom dữ dội của không quân Mỹ vào thành phố Kobe trong khi cha của hai đứa đang chiến đấu cho Hải quân hoàng gia Nhật."
                },
                new Movie
                {
                    Name = "School Days",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://cdn.myanimelist.net/images/anime/13/17594.jpg",
                    Release = new DateTime(2007, 1, 1),
                    View = 4000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[drama]},
                        new GenreMovie {Genre = genres[horror]},
                        new GenreMovie {Genre = genres[harem]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[schoolLife]}
                    },
                    Description =
                        "Chuyện về một anh chàng học sinh đào hoa, bắt cá 4-5 tay một lúc nhiều em. Cuối Film anh ấy đã chọn một được một người và cả hai cùng đi trên một cái Nice Boat đến một nơi chỉ của riêng hai người. "
                },
                new Movie
                {
                    Name = "Ansatsu Kyoushitsu",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/10/02/[animevsub.com]-assassination-classroom-blu-ray_821c3c82a7f9789192e7108ef48fcfa9.jpg",
                    Release = new DateTime(2015, 1, 1),
                    View = 4000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[action]},
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[schoolLife]},
                        new GenreMovie {Genre = genres[shounen]}
                    },
                    Description =
                        "Các học sinh của lớp 3-E có một nhiệm vụ: Giết thầy trước khi tốt nghiệp! Hắn đã phá hủy mặt trăng, hắn bay được với vận tốc 20 mach, hắn là một con bạch tuộc? Hắn vân vân và vân vân... Và ai có thể là thầy giáo tốt hơn hắn?!"
                },
                new Movie
                {
                    Name = "Nekopara",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2017/01/24/[animevsub.com]-neko-para_52fbe6bc4d785518296670706638f5a3.jpg",
                    Release = new DateTime(2017, 1, 1),
                    View = 4000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[ecchi]},
                        new GenreMovie {Genre = genres[romance]}
                    },
                    Description =
                        "Nekopara là gì?Tại sao, đây là con mèo của thiên đường. Kashou Minazuki, một hàng dài người Nhật chuyển ra, con trai của nhà sản xuất kẹo tự mở La Circus như một tiệm bánh ngọt. Nhưng trong di chuyển, ẩn trong đồ của hắn đều ở Catgirls (Cat), hay Carat và vani, gia đình này đã tăng.Khi hắn đang cố đưa họ đi, họ cầu xin cho đến khi hắn bây giờ họ đã mở rạp xiếc. Los Angeles cùng nhau. Hai nekos ai thực sự yêu chủ nhân của chúng trong họ nhất thỉnh thoảng thất bại... Chân thành hài, mở cửa!"
                },
                new Movie
                {
                    Name = "Bakemonogatari",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2015/02/05/[animevsub.com]-bakemonogatari_338a489a5bcf4cd296d0e05354c33f57.jpg",
                    Release = new DateTime(2010, 1, 1),
                    View = 3000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[vampire]},
                        new GenreMovie {Genre = genres[superNatural]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[mystery]}
                    },
                    Description =
                        "Mọi chuyện bắt đầu từ một sự kiện được nhắc đi nhắc lại nhan nhản trong phim, và sẽ được ra mắt trong movie Kizumonogatari trong 1 tương lai xa ngoài vùng phủ sóng (tạm gọi là X). Kể từ sau sự kiện X đó, Araragi Koyomi đã không còn là một học sinh cấp ba bình thường. Cậu sở hữu một sức mạnh cho phép cậu đeo đuổi một trong những sở thích ít ỏi của mình - nhúng mũi vào những rắc rối của người khác - đặc biệt là những rắc rối có liên quan đến hiện tượng siêu linh, do tinh linh gây ra.."
                }
            };

            #endregion

            #region episodes

            var episodes = new List<List<Episode>>();

            #region Sword Art Online

            var swordArtOnline = new List<Episode>
            {
                new Episode
                {
                    Name = "1",
                    Url = ConvertUrl("http://onecloud.media/file/14d2bdc89fe14910-c915ad8b3dbac0f3")
                },
                new Episode
                {
                    Name = "2",
                    Url = ConvertUrl("http://onecloud.media/file/f7a14b87e36ea73e-2239de2fe37078f6")
                },
                new Episode
                {
                    Name = "3",
                    Url = ConvertUrl("http://onecloud.media/file/91d301e21ababd36-b02005c7dbf77ff1")
                },
                new Episode
                {
                    Name = "4",
                    Url = ConvertUrl("http://onecloud.media/file/ff58f05f24d8ad0b-120eac724931153d")
                },
                new Episode
                {
                    Name = "5",
                    Url = ConvertUrl("http://onecloud.media/file/2387d0d2ae1ac7a6-1f5667c6806348d0")
                },
                new Episode
                {
                    Name = "6",
                    Url = ConvertUrl("http://onecloud.media/file/ec02dded64b5d3b7-a85230bceb3dd071")
                },
                new Episode
                {
                    Name = "7",
                    Url = ConvertUrl("http://onecloud.media/file/481555a8cad6a87d-f3c65cb4f33ac17d")
                },
                new Episode
                {
                    Name = "8",
                    Url = ConvertUrl("http://onecloud.media/file/66000501e196e5b8-2b06eb77a9d916b5")
                },
                new Episode
                {
                    Name = "9",
                    Url = ConvertUrl("http://onecloud.media/file/f224a405d86eda79-d9fbc93fe510b0bf")
                },
                new Episode
                {
                    Name = "10",
                    Url = ConvertUrl("http://onecloud.media/file/dd12c18c14bb7c0c-5c565cef8ef359db")
                },
                new Episode
                {
                    Name = "11",
                    Url = ConvertUrl("http://onecloud.media/file/4bc77cb9eddf345f-c2f818f6ba3f9d00")
                },
                new Episode
                {
                    Name = "12",
                    Url = ConvertUrl("http://onecloud.media/file/20da5d038f9288b9-5a5888599d28115f")
                },
                new Episode
                {
                    Name = "13",
                    Url = ConvertUrl("http://onecloud.media/file/aec7992cd4c556c3-cecb97cae9fed836")
                },
                new Episode
                {
                    Name = "14",
                    Url = ConvertUrl("http://onecloud.media/file/079a7352466f41bb-6b47b67fa193c4fe")
                },
                new Episode
                {
                    Name = "15",
                    Url = ConvertUrl("http://onecloud.media/file/95e927ee6c5c45d3-265d8d7ad8d36b30")
                },
                new Episode
                {
                    Name = "16",
                    Url = ConvertUrl("http://onecloud.media/file/f72e82ec08987a90-57b91305983f80e8")
                },
                new Episode
                {
                    Name = "17",
                    Url = ConvertUrl("http://onecloud.media/file/6559da5a75d15f5a-33bffd64cc3a4f3e")
                },
                new Episode
                {
                    Name = "18",
                    Url = ConvertUrl("http://onecloud.media/file/ec6e16404a80d425-a91b2c36d9f034bf")
                },
                new Episode
                {
                    Name = "19",
                    Url = ConvertUrl("http://onecloud.media/file/1ded0b56657c176c-0e206e38bfda8f15")
                },
                new Episode
                {
                    Name = "20",
                    Url = ConvertUrl("http://onecloud.media/file/56ba47e09e994f06-4dd5cc22016a85b6")
                },
                new Episode
                {
                    Name = "21",
                    Url = ConvertUrl("http://onecloud.media/file/b7e5d861a4dba83d-54a88527ae301bab")
                },
                new Episode
                {
                    Name = "22",
                    Url = ConvertUrl("http://onecloud.media/file/319c87a03866ea3c-cfc475aeb078c6d3")
                },
                new Episode
                {
                    Name = "23",
                    Url = ConvertUrl("http://onecloud.media/file/ed6b1f1da83421ae-9ef6943fa580584c")
                },
                new Episode
                {
                    Name = "24",
                    Url = ConvertUrl("http://onecloud.media/file/658f713411e2946f-fa64410cfac648fd")
                },
                new Episode
                {
                    Name = "25",
                    Url = ConvertUrl("http://onecloud.media/file/7d89cc191f0be8fb-368333aeed6c0e47")
                }
            };

            swordArtOnline.ForEach(x => x.Movie = movies.Single(m => m.Name == "Sword Art Online"));
            episodes.Add(swordArtOnline);

            #endregion

            #region Mahouka Koukou No Rettousei

            var mahouka = new List<Episode>
            {
                new Episode
                {
                    Name = "1",
                    Url = ConvertUrl("http://onecloud.media/file/ea0a4f0592876bc6-0d45215fe94e9118")
                },
                new Episode
                {
                    Name = "2",
                    Url = ConvertUrl("http://onecloud.media/file/6f37b5f4547cfc91-6174b37da791b89b")
                },
                new Episode
                {
                    Name = "3",
                    Url = ConvertUrl("http://onecloud.media/file/43b9a4368d3e7099-e51029d2a7731cb2")
                },
                new Episode
                {
                    Name = "4",
                    Url = ConvertUrl("http://onecloud.media/file/db3e17aca1134556-9d5d11d30d57e476")
                },
                new Episode
                {
                    Name = "5",
                    Url = ConvertUrl("http://onecloud.media/file/2ae2e1d5912afdeb-25b34a3986df13f8")
                },
                new Episode
                {
                    Name = "6",
                    Url = ConvertUrl("http://onecloud.media/file/4cc4eb8020c49482-d79bf2b010c1f242")
                },
                new Episode
                {
                    Name = "7",
                    Url = ConvertUrl("http://onecloud.media/file/c6572c530dc167b9-602b186e8ed2e62d")
                },
                new Episode
                {
                    Name = "8",
                    Url = ConvertUrl("http://onecloud.media/file/d5a5206e03e39a6c-824e7fff8c8fd8b7")
                },
                new Episode
                {
                    Name = "9",
                    Url = ConvertUrl("http://onecloud.media/file/e4b606b938b0a456-8a1dff7151546259")
                },
                new Episode
                {
                    Name = "10",
                    Url = ConvertUrl("http://onecloud.media/file/a42d41532a1418e2-61aa7f56331c324e")
                },
                new Episode
                {
                    Name = "11",
                    Url = ConvertUrl("http://onecloud.media/file/a010ee7ca500fb92-0223502ac1ba53c4")
                },
                new Episode
                {
                    Name = "12",
                    Url = ConvertUrl("http://onecloud.media/file/40947c782ad46fc0-4538069412b88ef8")
                },
                new Episode
                {
                    Name = "13",
                    Url = ConvertUrl("http://onecloud.media/file/492088a83a103bdf-8c6a73082b1d123d")
                },
                new Episode
                {
                    Name = "14",
                    Url = ConvertUrl("http://onecloud.media/file/9f199f65948a7398-2b34960ee95f7ca5")
                },
                new Episode
                {
                    Name = "15",
                    Url = ConvertUrl("http://onecloud.media/file/bd4aab148391128d-cec6ee7fb1eb84dd")
                },
                new Episode
                {
                    Name = "16",
                    Url = ConvertUrl("http://onecloud.media/file/c09f882f3c1bb1e1-f1846b8aa9b9dde7")
                },
                new Episode
                {
                    Name = "17",
                    Url = ConvertUrl("http://onecloud.media/file/32efdc95d81e724a-50b3e24dd2f8ab74")
                },
                new Episode
                {
                    Name = "18",
                    Url = ConvertUrl("http://onecloud.media/file/9eca17072ad334f9-8a74deb120d6489b")
                },
                new Episode
                {
                    Name = "19",
                    Url = ConvertUrl("http://onecloud.media/file/8d4c73ab391810f6-88a107484f19f0f2")
                },
                new Episode
                {
                    Name = "20",
                    Url = ConvertUrl("http://onecloud.media/file/ba9d580b536baf9b-537a71ffd08ef901")
                },
                new Episode
                {
                    Name = "21",
                    Url = ConvertUrl("http://onecloud.media/file/243005ab7f650c06-8095592bcd815e0c")
                },
                new Episode
                {
                    Name = "22",
                    Url = ConvertUrl("http://onecloud.media/file/e0ba292098e9c755-ed32bd89e94f96fe")
                },
                new Episode
                {
                    Name = "23",
                    Url = ConvertUrl("http://onecloud.media/file/5e4e7ff2c22199ae-8b8aa48007e26084")
                },
                new Episode
                {
                    Name = "24",
                    Url = ConvertUrl("http://onecloud.media/file/1052bc7964e56a74-65e66f29df79e37b")
                },
                new Episode
                {
                    Name = "25",
                    Url = ConvertUrl("http://onecloud.media/file/4d276db4e26b317f-8cd8e394a7d50862")
                },
                new Episode
                {
                    Name = "26",
                    Url = ConvertUrl("http://onecloud.media/file/b172f3e6be89eba9-d6ed8d203421ae20")
                }
            };

            mahouka.ForEach(x => x.Movie = movies.Single(m => m.Name == "Mahouka Koukou No Rettousei"));
            episodes.Add(mahouka);

            #endregion

            #region Kimi No Na Wa

            var kimiNoNaWa = new List<Episode>
            {
                new Episode
                {
                    Name = "FULL",
                    Url = ConvertUrl("http://onecloud.media/file/5cb9d32a375f559f-777ea89f84aab4dd")
                }
            };

            kimiNoNaWa.ForEach(x => x.Movie = movies.Single(m => m.Name == "Kimi No Na Wa"));
            episodes.Add(kimiNoNaWa);

            #endregion

            #region Sword Art Online 2

            var swordArtOnline2 = new List<Episode>
            {
                new Episode
                {
                    Name = "1",
                    Url = ConvertUrl("http://onecloud.media/file/f95dcef97e1c9ac3-84047d9ec7df8048")
                },
                new Episode
                {
                    Name = "2",
                    Url = ConvertUrl("http://onecloud.media/file/4322f2c460465280-ac7147795579e3ca")
                },
                new Episode
                {
                    Name = "3",
                    Url = ConvertUrl("http://onecloud.media/file/4197696b38e8fe19-9618be1e5b0db274")
                },
                new Episode
                {
                    Name = "4",
                    Url = ConvertUrl("http://onecloud.media/file/6e7fc19b7743d69a-c56e536d1573342d")
                },
                new Episode
                {
                    Name = "5",
                    Url = ConvertUrl("http://onecloud.media/file/d4f9929f6284fd6d-caa2299aeb94bdfa")
                },
                new Episode
                {
                    Name = "6",
                    Url = ConvertUrl("http://onecloud.media/file/315b9fd7fd87d061-9df62afb34bf909c")
                },
                new Episode
                {
                    Name = "7",
                    Url = ConvertUrl("http://onecloud.media/file/a6c8c9bef0b02e03-7b6b22100ed2aacf")
                },
                new Episode
                {
                    Name = "8",
                    Url = ConvertUrl("http://onecloud.media/file/e52c1d65bbf4e6c4-5927629ddb67f833")
                },
                new Episode
                {
                    Name = "9",
                    Url = ConvertUrl("http://onecloud.media/file/0cd9a89a78125fc0-357f7ee8fbfb3779")
                },
                new Episode
                {
                    Name = "10",
                    Url = ConvertUrl("http://onecloud.media/file/b197491978c91b9e-b0d9c01807e2565f")
                },
                new Episode
                {
                    Name = "11",
                    Url = ConvertUrl("http://onecloud.media/file/2a9f52a53f692389-27f619a91f7b5bd5")
                },
                new Episode
                {
                    Name = "12",
                    Url = ConvertUrl("http://onecloud.media/file/d2a704152d7a13a9-df316bbe1c307250")
                },
                new Episode
                {
                    Name = "13",
                    Url = ConvertUrl("http://onecloud.media/file/cb0aa9cf4a44d303-b0afe57cb8edca64")
                },
                new Episode
                {
                    Name = "14",
                    Url = ConvertUrl("http://onecloud.media/file/83be1b1c4d6168ee-bc62ed3ddbddfbec")
                },
                new Episode
                {
                    Name = "15",
                    Url = ConvertUrl("http://onecloud.media/file/31e7e636f2ba57b9-82301766174cf4a9")
                },
                new Episode
                {
                    Name = "16",
                    Url = ConvertUrl("http://onecloud.media/file/4b454dc3562525ff-f29de606eec3ae62")
                },
                new Episode
                {
                    Name = "17",
                    Url = ConvertUrl("http://onecloud.media/file/3f1b83716ebeb838-1ec9e615fd5f74a7")
                },
                new Episode
                {
                    Name = "18",
                    Url = ConvertUrl("http://onecloud.media/file/b913fcf841203411-287cdd0d595bbb89")
                },
                new Episode
                {
                    Name = "19",
                    Url = ConvertUrl("http://onecloud.media/file/12e29890c34e9ce6-bb70d79de7375e09")
                },
                new Episode
                {
                    Name = "20",
                    Url = ConvertUrl("http://onecloud.media/file/1521558eebf7cc84-75261aa55c2f8d14")
                },
                new Episode
                {
                    Name = "21",
                    Url = ConvertUrl("http://onecloud.media/file/84310e12cc5a7586-77038641a1b05f8e")
                },
                new Episode
                {
                    Name = "22",
                    Url = ConvertUrl("http://onecloud.media/file/7c485c0ccd685d47-545ccaec6bcc86aa")
                },
                new Episode
                {
                    Name = "23",
                    Url = ConvertUrl("http://onecloud.media/file/8f36cbc6fb97baa4-a9b6b553c5ea483d")
                },
                new Episode
                {
                    Name = "24",
                    Url = ConvertUrl("http://onecloud.media/file/e35f3d7d64a5c18c-5b0bd8b81970ec68")
                }
            };

            swordArtOnline2.ForEach(x => x.Movie = movies.Single(m => m.Name == "Sword Art Online II : Phantom Bullet"));
            episodes.Add(swordArtOnline2);

            #endregion

            #region Cardcaptor Sakura

            var cardcaptorSakura = new List<Episode>
            {
                new Episode
                {
                    Name = "1",
                    Url = ConvertUrl("http://onecloud.media/file/c848d82df460347b-cc6672285de6cac6")
                },
                new Episode
                {
                    Name = "2",
                    Url = ConvertUrl("http://onecloud.media/file/7cfe0022dbeff5f9-c60930340818db41")
                },
                new Episode
                {
                    Name = "3",
                    Url = ConvertUrl("http://onecloud.media/file/398ecc2969e0136f-e2ded4679bc7df12")
                },
                new Episode
                {
                    Name = "4",
                    Url = ConvertUrl("http://onecloud.media/file/99cc8d310254ef66-b8c9936204a234a7")
                },
                new Episode
                {
                    Name = "5",
                    Url = ConvertUrl("http://onecloud.media/file/49230f7936e4f2e2-8d7c1a70b8cc89ac")
                },
                new Episode
                {
                    Name = "6",
                    Url = ConvertUrl("http://onecloud.media/file/6433e47ebd98471d-e266ae60face508c")
                },
                new Episode
                {
                    Name = "7",
                    Url = ConvertUrl("http://onecloud.media/file/2bdff10150dfb506-7c483d7931d0b8a0")
                },
                new Episode
                {
                    Name = "8",
                    Url = ConvertUrl("http://onecloud.media/file/8bce0408361c2355-34012992c4a9691a")
                },
                new Episode
                {
                    Name = "9",
                    Url = ConvertUrl("http://onecloud.media/file/54f2dd1d7c3772f7-547182b653406698")
                },
                new Episode
                {
                    Name = "10",
                    Url = ConvertUrl("http://onecloud.media/file/9cdf21402bd6bd7d-184643c357f8e71d")
                },
                new Episode
                {
                    Name = "11",
                    Url = ConvertUrl("http://onecloud.media/file/7b3b68774945aa30-b4b581ffb280f70a")
                },
                new Episode
                {
                    Name = "12",
                    Url = ConvertUrl("http://onecloud.media/file/3ad90107aaa00ed1-ff6ae10ef6cf17c7")
                },
                new Episode
                {
                    Name = "13",
                    Url = ConvertUrl("http://onecloud.media/file/a5d0daa760219399-7e8aa0755b5b9bea")
                },
                new Episode
                {
                    Name = "14",
                    Url = ConvertUrl("http://onecloud.media/file/411d87aabdaed83d-53c8669be5ba0027")
                },
                new Episode
                {
                    Name = "15",
                    Url = ConvertUrl("http://onecloud.media/file/d3f016f09c7962b6-e93bcbae4006c837")
                },
                new Episode
                {
                    Name = "16",
                    Url = ConvertUrl("http://onecloud.media/file/d36cc4d3167a2619-a8b52f272379638f")
                },
                new Episode
                {
                    Name = "17",
                    Url = ConvertUrl("http://onecloud.media/file/32e2d64afc15fd2e-d5964eb523174dbe")
                },
                new Episode
                {
                    Name = "18",
                    Url = ConvertUrl("http://onecloud.media/file/00d8c27da0ec8fa9-24c92f307bc0b0dd")
                },
                new Episode
                {
                    Name = "19",
                    Url = ConvertUrl("http://onecloud.media/file/0d5ba696625ae9b9-580ae6d6f8d834e3")
                },
                new Episode
                {
                    Name = "20",
                    Url = ConvertUrl("http://onecloud.media/file/bf4f1fc3af2b9b7b-b4b6914c2be490a1")
                },
                new Episode
                {
                    Name = "21",
                    Url = ConvertUrl("http://onecloud.media/file/efe9f1604f32750b-53d779082fd7b14b")
                },
                new Episode
                {
                    Name = "22",
                    Url = ConvertUrl("http://onecloud.media/file/5479933c1a4ffb89-e0db838bab5b789e")
                },
                new Episode
                {
                    Name = "23",
                    Url = ConvertUrl("http://onecloud.media/file/699b83d809628ef9-bbb3d6681c51d8e6")
                },
                new Episode
                {
                    Name = "24",
                    Url = ConvertUrl("http://onecloud.media/file/8b4ec6563598153c-3ffdb64869629491")
                },
                new Episode
                {
                    Name = "25",
                    Url = ConvertUrl("http://onecloud.media/file/5f2d6edc740ba332-a4572289a9fe7323")
                },
                new Episode
                {
                    Name = "26",
                    Url = ConvertUrl("http://onecloud.media/file/6d3c7bc95bd17c85-15dffe2e77a4204f")
                },
                new Episode
                {
                    Name = "27",
                    Url = ConvertUrl("http://onecloud.media/file/557a99520ae0e2a4-8606db29f879ff22")
                },
                new Episode
                {
                    Name = "28",
                    Url = ConvertUrl("http://onecloud.media/file/6631ae70ba5a91fa-d7c8308c57916b07")
                },
                new Episode
                {
                    Name = "29",
                    Url = ConvertUrl("http://onecloud.media/file/ee240d7837b07edf-b7ba2eb33a642e25")
                },
                new Episode
                {
                    Name = "30",
                    Url = ConvertUrl("http://onecloud.media/file/89d99b2a2ac1b4db-4e57c6a2df7c333e")
                },
                new Episode
                {
                    Name = "31",
                    Url = ConvertUrl("http://onecloud.media/file/3611c015a3b15b00-644be15b04662d68")
                },
                new Episode
                {
                    Name = "32",
                    Url = ConvertUrl("http://onecloud.media/file/1ac9c10f9198554c-d53eeb0054088222")
                },
                new Episode
                {
                    Name = "33",
                    Url = ConvertUrl("http://onecloud.media/file/b15b7a7c8e4fe925-3518e9519ba2b5a8")
                },
                new Episode
                {
                    Name = "34",
                    Url = ConvertUrl("http://onecloud.media/file/7eca10ee15255f86-5176431d51fe6ff3")
                },
                new Episode
                {
                    Name = "35",
                    Url = ConvertUrl("http://onecloud.media/file/12e10b5636d5f5fd-5b6d36ced43d0f89")
                },
                new Episode
                {
                    Name = "36",
                    Url = ConvertUrl("http://onecloud.media/file/b1cadd240d8280f5-73ddc03cc42580a8")
                },
                new Episode
                {
                    Name = "37",
                    Url = ConvertUrl("http://onecloud.media/file/c14e6f23f6c49016-1f6986f8c469b99e")
                },
                new Episode
                {
                    Name = "38",
                    Url = ConvertUrl("http://onecloud.media/file/1457b74e20072f60-bf612f722da48e03")
                },
                new Episode
                {
                    Name = "39",
                    Url = ConvertUrl("http://onecloud.media/file/6f8f77352dbac0d4-4a502ec18619d640")
                },
                new Episode
                {
                    Name = "40",
                    Url = ConvertUrl("http://onecloud.media/file/cb9d678543265d18-99a34ce4cb15530b")
                },
                new Episode
                {
                    Name = "41",
                    Url = ConvertUrl("http://onecloud.media/file/5207987ab96851ce-7614b43f553adfe2")
                },
                new Episode
                {
                    Name = "42",
                    Url = ConvertUrl("http://onecloud.media/file/5207987ab96851ce-7614b43f553adfe2")
                },
                new Episode
                {
                    Name = "43",
                    Url = ConvertUrl("http://onecloud.media/file/cf55331fb11ebd6e-7216c657462404e8")
                },
                new Episode
                {
                    Name = "44",
                    Url = ConvertUrl("http://onecloud.media/file/8ea7966b25552a57-34d4d37c5c7e430d")
                },
                new Episode
                {
                    Name = "45",
                    Url = ConvertUrl("http://onecloud.media/file/85889ed4fa750c8a-b99e8ff6a24fb092")
                },
                new Episode
                {
                    Name = "46",
                    Url = ConvertUrl("http://onecloud.media/file/005629552826b2b1-f93c7994f1620164")
                },
                new Episode
                {
                    Name = "47",
                    Url = ConvertUrl("http://onecloud.media/file/4d5c67d7e2f7e8fe-27b222f82b33fabd")
                },
                new Episode
                {
                    Name = "48",
                    Url = ConvertUrl("http://onecloud.media/file/944dd4cd82db6cf3-d5b3092c2be8feac")
                },
                new Episode
                {
                    Name = "49",
                    Url = ConvertUrl("http://onecloud.media/file/be59c9f65460c0e5-90a869e5fdac5c4a")
                },
                new Episode
                {
                    Name = "50",
                    Url = ConvertUrl("http://onecloud.media/file/3f53085550ab28cc-3e09cea92f11ba0e")
                },
                new Episode
                {
                    Name = "51",
                    Url = ConvertUrl("http://onecloud.media/file/3928685fba028bb2-cceef7bd8bcff0d5")
                },
                new Episode
                {
                    Name = "52",
                    Url = ConvertUrl("http://onecloud.media/file/458503a7ca726c33-2a538cbda855dbf1")
                },
                new Episode
                {
                    Name = "53",
                    Url = ConvertUrl("http://onecloud.media/file/0dbfa61bcde3b024-e2ad976c2ecd07b6")
                },
                new Episode
                {
                    Name = "54",
                    Url = ConvertUrl("http://onecloud.media/file/4309e939bc96a68e-7b030281e6309453")
                },
                new Episode
                {
                    Name = "55",
                    Url = ConvertUrl("http://onecloud.media/file/922622d7a858800d-6a2ccb455132d911")
                },
                new Episode
                {
                    Name = "56",
                    Url = ConvertUrl("http://onecloud.media/file/248f14cfd144d0c5-7c030f305c5b8c67")
                },
                new Episode
                {
                    Name = "57",
                    Url = ConvertUrl("http://onecloud.media/file/5a804c80b66267d1-44f3e2ac8f4bb635")
                },
                new Episode
                {
                    Name = "58",
                    Url = ConvertUrl("http://onecloud.media/file/931cee1f9b2fc6d2-fad0482ced19d8f0")
                },
                new Episode
                {
                    Name = "59",
                    Url = ConvertUrl("http://onecloud.media/file/0663094a8fea6600-36d504836731b44b")
                },
                new Episode
                {
                    Name = "60",
                    Url = ConvertUrl("http://onecloud.media/file/97dcddade7875c3a-2164b9ec1f9ff4b9")
                },
                new Episode
                {
                    Name = "61",
                    Url = ConvertUrl("http://onecloud.media/file/e43d5feeba25f06c-0d37e15b2035cf37")
                },
                new Episode
                {
                    Name = "62",
                    Url = ConvertUrl("http://onecloud.media/file/04399f19b2d2c629-c3e075d1639f7876")
                },
                new Episode
                {
                    Name = "63",
                    Url = ConvertUrl("http://onecloud.media/file/e3188dbd23e4f74e-595941b0406bc558")
                },
                new Episode
                {
                    Name = "64",
                    Url = ConvertUrl("http://onecloud.media/file/7ebc359adb773e54-84c54b0014f9b12b")
                },
                new Episode
                {
                    Name = "65",
                    Url = ConvertUrl("http://onecloud.media/file/ae32650655a2a6f7-a08cfa48ec8326ca")
                },
                new Episode
                {
                    Name = "66",
                    Url = ConvertUrl("http://onecloud.media/file/7d8ba3460c9a4079-4df7bfc11c7993f1")
                },
                new Episode
                {
                    Name = "67",
                    Url = ConvertUrl("http://onecloud.media/file/54c2a9197ce0590f-84f9879509c618d0")
                },
                new Episode
                {
                    Name = "68",
                    Url = ConvertUrl("http://onecloud.media/file/4b6a52ca0f08b876-5bc095b5627b605f")
                },
                new Episode
                {
                    Name = "69",
                    Url = ConvertUrl("http://onecloud.media/file/85c321349e98e8b1-5090a3f864e763f4")
                },
                new Episode
                {
                    Name = "70",
                    Url = ConvertUrl("http://onecloud.media/file/ae2ebe23378c88bb-1da95a8a736b75bb")
                }
            };

            cardcaptorSakura.ForEach(x => x.Movie = movies.Single(m => m.Name == "Cardcaptor Sakura"));
            episodes.Add(cardcaptorSakura);

            #endregion

            #region Dragon Ball Super

            var dragonBallSuper = new List<Episode>
            {
                new Episode
                {
                    Name = "1",
                    Url = ConvertUrl("http://onecloud.media/file/1039b6913f0a0bab-00aa649d210e1331")
                },
                new Episode
                {
                    Name = "2",
                    Url = ConvertUrl("http://onecloud.media/file/90ef897b7c8c5d83-e4743c999b87af75")
                },
                new Episode
                {
                    Name = "3",
                    Url = ConvertUrl("http://onecloud.media/file/45b67cd3521b4495-550f4c7ae12c9a54")
                },
                new Episode
                {
                    Name = "4",
                    Url = ConvertUrl("http://onecloud.media/file/be8567dd3b35a8d0-0d7948fc60f8a59f")
                },
                new Episode
                {
                    Name = "5",
                    Url = ConvertUrl("http://onecloud.media/file/be8567dd3b35a8d0-0d7948fc60f8a59f")
                },
                new Episode
                {
                    Name = "6",
                    Url = ConvertUrl("http://onecloud.media/file/a9ece055cba4d850-abe85c6a780fd174")
                },
                new Episode
                {
                    Name = "7",
                    Url = ConvertUrl("http://onecloud.media/file/158c6bc34655674f-eef38ad7a01a955d")
                },
                new Episode
                {
                    Name = "8",
                    Url = ConvertUrl("http://onecloud.media/file/158c6bc34655674f-eef38ad7a01a955d")
                },
                new Episode
                {
                    Name = "9",
                    Url = ConvertUrl("http://onecloud.media/file/bac25fcdf117920f-fa24b1803fbfa010")
                },
                new Episode
                {
                    Name = "10",
                    Url = ConvertUrl("http://onecloud.media/file/b74ee4f9ef6a4d5d-dd005b3874a6d9be")
                },
                new Episode
                {
                    Name = "11",
                    Url = ConvertUrl("http://onecloud.media/file/c7247dc592e5fc3d-13fc7d289cfd35d6")
                },
                new Episode
                {
                    Name = "12",
                    Url = ConvertUrl("http://onecloud.media/file/a3e6a3648273ac14-6653a1f68837e1c4")
                },
                new Episode
                {
                    Name = "13",
                    Url = ConvertUrl("http://onecloud.media/file/8709e198fac10834-b9a88f026b041f20")
                },
                new Episode
                {
                    Name = "14",
                    Url = ConvertUrl("http://onecloud.media/file/6daea08b05d0db70-1521886b4f9c0c87")
                },
                new Episode
                {
                    Name = "15",
                    Url = ConvertUrl("http://onecloud.media/file/53b445c774148905-05c06a65a1c84269")
                },
                new Episode
                {
                    Name = "16",
                    Url = ConvertUrl("http://onecloud.media/file/70b176bd92f82d41-e9fdcc6e1a6e412c")
                },
                new Episode
                {
                    Name = "17",
                    Url = ConvertUrl("http://onecloud.media/file/29df70107a58879e-b890e80261edfeab")
                },
                new Episode
                {
                    Name = "18",
                    Url = ConvertUrl("http://onecloud.media/file/6624faff02b23c8f-3c0c11b2c105ded9")
                },
                new Episode
                {
                    Name = "19",
                    Url = ConvertUrl("http://onecloud.media/file/b07881c23ab48b9d-83d8f72adacbf77e")
                },
                new Episode
                {
                    Name = "20",
                    Url = ConvertUrl("http://onecloud.media/file/12f812f67c6e4458-e422415c8c327f4b")
                },
                new Episode
                {
                    Name = "21",
                    Url = ConvertUrl("http://onecloud.media/file/1de810e56de4685c-c887b13ae7570ec0")
                },
                new Episode
                {
                    Name = "22",
                    Url = ConvertUrl("http://onecloud.media/file/5cdaca1e0fca94ba-179d3043cbbf0d6e")
                },
                new Episode
                {
                    Name = "23",
                    Url = ConvertUrl("http://onecloud.media/file/ecd0ac9f68e37c0b-7f4f7d9ab8a59ea4")
                },
                new Episode
                {
                    Name = "24",
                    Url = ConvertUrl("http://onecloud.media/file/725aabf8d6601631-ba7a6ca5bd67819c")
                },
                new Episode
                {
                    Name = "25",
                    Url = ConvertUrl("http://onecloud.media/file/52dadcfa8913b223-c9077a8ac7a9c8b0")
                },
                new Episode
                {
                    Name = "26",
                    Url = ConvertUrl("http://onecloud.media/file/e0a156bdec997872-9cf264b0396c51cd")
                },
                new Episode
                {
                    Name = "27",
                    Url = ConvertUrl("http://onecloud.media/file/92ecadb4bdc29329-e857aaeaa6e95aa1")
                },
                new Episode
                {
                    Name = "28",
                    Url = ConvertUrl("http://onecloud.media/file/85a13a85ef7bbac2-442f3c072b41c021")
                },
                new Episode
                {
                    Name = "29",
                    Url = ConvertUrl("http://onecloud.media/file/5734246f21c82c86-65251d7ede42ebf2")
                },
                new Episode
                {
                    Name = "30",
                    Url = ConvertUrl("http://onecloud.media/file/c3448aceaa14963f-87dbae70f00b9408")
                },
                new Episode
                {
                    Name = "31",
                    Url = ConvertUrl("http://onecloud.media/file/c73303e673efd741-4ad9e7eeed52d460")
                },
                new Episode
                {
                    Name = "32",
                    Url = ConvertUrl("http://onecloud.media/file/46decf1f81b282a2-f402f3b5ba1f4124")
                },
                new Episode
                {
                    Name = "33",
                    Url = ConvertUrl("http://onecloud.media/file/d70914a6e75f203f-7376613f8ebb2416")
                },
                new Episode
                {
                    Name = "34",
                    Url = ConvertUrl("http://onecloud.media/file/6291ec9043ef9ef6-f8d7e3e0678a7c4b")
                },
                new Episode
                {
                    Name = "35",
                    Url = ConvertUrl("http://onecloud.media/file/d99d692135d368bb-e8779642d73cc149")
                },
                new Episode
                {
                    Name = "36",
                    Url = ConvertUrl("http://onecloud.media/file/93981fb7dbd9292d-c5877ca2ecfbb881")
                },
                new Episode
                {
                    Name = "37",
                    Url = ConvertUrl("http://onecloud.media/file/a779165bf064963e-1387e9a0a575cfe0")
                },
                new Episode
                {
                    Name = "38",
                    Url = ConvertUrl("http://onecloud.media/file/45337e50dcef6298-2c8a493d3a197fab")
                },
                new Episode
                {
                    Name = "39",
                    Url = ConvertUrl("http://onecloud.media/file/594679950d9d5b4f-942aa467d954a595")
                },
                new Episode
                {
                    Name = "40",
                    Url = ConvertUrl("http://onecloud.media/file/ad66968636a6b0b3-9a2281a6dbab29b4")
                },
                new Episode
                {
                    Name = "41",
                    Url = ConvertUrl("http://onecloud.media/file/50363998a95c68a7-9b29ade6f39e8c46")
                },
                new Episode
                {
                    Name = "42",
                    Url = ConvertUrl("http://onecloud.media/file/60587f97d574e771-d7d947888679d682")
                },
                new Episode
                {
                    Name = "43",
                    Url = ConvertUrl("http://onecloud.media/file/4e0efc50de855223-be9340e83bc3b4bf")
                },
                new Episode
                {
                    Name = "44",
                    Url = ConvertUrl("http://onecloud.media/file/166f8fa6482af733-c1be53da3345c0eb")
                },
                new Episode
                {
                    Name = "45",
                    Url = ConvertUrl("http://onecloud.media/file/a170e8931147b0ae-61061754678f636c")
                },
                new Episode
                {
                    Name = "46",
                    Url = ConvertUrl("http://onecloud.media/file/f56630841a33160c-9f60d64e2a92dbe0")
                },
                new Episode
                {
                    Name = "47",
                    Url = ConvertUrl("http://onecloud.media/file/f0878f7a68a14951-385a8efdb6d13827")
                },
                new Episode
                {
                    Name = "48",
                    Url = ConvertUrl("http://onecloud.media/file/c956399a77153fba-66a2c4dc8f2a52b9")
                },
                new Episode
                {
                    Name = "49",
                    Url = ConvertUrl("http://onecloud.media/file/36469c9247ae6eda-625db30630717379")
                },
                new Episode
                {
                    Name = "50",
                    Url = ConvertUrl("http://onecloud.media/file/443eda8da644aa02-0feab7e9064cc056")
                },
                new Episode
                {
                    Name = "51",
                    Url = ConvertUrl("http://onecloud.media/file/fe5723f4baa93522-4715ea6637bee797")
                },
                new Episode
                {
                    Name = "52",
                    Url = ConvertUrl("http://onecloud.media/file/b4ba69358c67dfb5-f98e8644c95d37f7")
                },
                new Episode
                {
                    Name = "53",
                    Url = ConvertUrl("http://onecloud.media/file/6b5ef0be6b78b555-f4238ac7c5c02962")
                },
                new Episode
                {
                    Name = "54",
                    Url = ConvertUrl("http://onecloud.media/file/c1a21069c286db83-80ef3c4cd465965a")
                },
                new Episode
                {
                    Name = "55",
                    Url = ConvertUrl("http://onecloud.media/file/59cb403b5ee74923-24bee016006e2d9a")
                },
                new Episode
                {
                    Name = "56",
                    Url = ConvertUrl("http://onecloud.media/file/79a553bcdb3937a5-e7d05139e8df2653")
                },
                new Episode
                {
                    Name = "57",
                    Url = ConvertUrl("http://onecloud.media/file/e7e622947f91a6ce-fbca964c1f0a8953")
                },
                new Episode
                {
                    Name = "58",
                    Url = ConvertUrl("http://onecloud.media/file/e1bd48cfe5ec5bb3-af5c20f9374bb141")
                },
                new Episode
                {
                    Name = "59",
                    Url = ConvertUrl("http://onecloud.media/file/ce113b9c667a2d37-a6c475756fa752ff")
                },
                new Episode
                {
                    Name = "60",
                    Url = ConvertUrl("http://onecloud.media/file/6480621a94965df2-c58a7a6f93f6002d")
                },
                new Episode
                {
                    Name = "61",
                    Url = ConvertUrl("http://onecloud.media/file/d1e8e84b70321241-8c6a98c687ee01dc")
                },
                new Episode
                {
                    Name = "62",
                    Url = ConvertUrl("http://onecloud.media/file/c3b6605036714dab-b052575a1a46e8b4")
                },
                new Episode
                {
                    Name = "63",
                    Url = ConvertUrl("http://onecloud.media/file/5d2ac68ebbc58218-1809016d47012737")
                },
                new Episode
                {
                    Name = "64",
                    Url = ConvertUrl("http://onecloud.media/file/ab5d335e30862cec-aba23d7a7b789ee2")
                },
                new Episode
                {
                    Name = "65",
                    Url = ConvertUrl("http://onecloud.media/file/d2c1c7e76e84d2a9-cc5c2528e863ee49")
                },
                new Episode
                {
                    Name = "66",
                    Url = ConvertUrl("http://onecloud.media/file/a75c70bbb1dacf13-c4b50be2107c9889")
                },
                new Episode
                {
                    Name = "67",
                    Url = ConvertUrl("http://onecloud.media/file/e38719b0d4aaf4b9-ae71d5b343d5e618")
                },
                new Episode
                {
                    Name = "68",
                    Url = ConvertUrl("http://onecloud.media/file/62099f091d03499f-c91684e5eb925814")
                },
                new Episode
                {
                    Name = "69",
                    Url = ConvertUrl("http://onecloud.media/file/f4a7470baec0499d-81adfac206b7bff4")
                },
                new Episode
                {
                    Name = "70",
                    Url = ConvertUrl("http://onecloud.media/file/6104c191271b91f9-3cbb3abf4a967724")
                },
                new Episode
                {
                    Name = "71",
                    Url = ConvertUrl("http://onecloud.media/file/594a334bd3769a04-e4431a6f8df566cf")
                },
                new Episode
                {
                    Name = "72",
                    Url = ConvertUrl("http://onecloud.media/file/29827e3fd27eb4a9-c181fadc0279d0b6")
                },
                new Episode
                {
                    Name = "73",
                    Url = ConvertUrl("http://onecloud.media/file/053601146dd0589d-3db0db32aaebdbd5")
                },
                new Episode
                {
                    Name = "74",
                    Url = ConvertUrl("http://onecloud.media/file/a0aa33e74a61a0d5-eefd09774c2cacf9")
                },
                new Episode
                {
                    Name = "75",
                    Url = ConvertUrl("http://onecloud.media/file/381e81a685b0abeb-22a812140a4fcee1")
                },
                new Episode
                {
                    Name = "76",
                    Url = ConvertUrl("http://onecloud.media/file/e3148f89dfb9ec3d-a21a282843cb6532")
                },
                new Episode
                {
                    Name = "77",
                    Url = ConvertUrl("http://onecloud.media/file/56fe28724d5ffaa8-69a6b627735edcc1")
                },
                new Episode
                {
                    Name = "78",
                    Url = ConvertUrl("http://onecloud.media/file/301261bfcbb1fd1d-2d4c6523fe6785dd")
                },
                new Episode
                {
                    Name = "79",
                    Url = ConvertUrl("http://onecloud.media/file/ce9bb43635ff4a7c-cb84db1e19c80d28")
                },
                new Episode
                {
                    Name = "80",
                    Url = ConvertUrl("http://onecloud.media/file/8837a9bf501af3b6-5839533dde4d8470")
                },
                new Episode
                {
                    Name = "81",
                    Url = ConvertUrl("http://onecloud.media/file/33449015f613769b-2ed831de06916ace")
                },
                new Episode
                {
                    Name = "82",
                    Url = ConvertUrl("http://onecloud.media/file/bdd9239033b6f9f9-d270dcaa7b4756dd")
                },
                new Episode
                {
                    Name = "83",
                    Url = ConvertUrl("http://onecloud.media/file/4d92e053d595750a-a319de686e14e08e")
                }
            };

            dragonBallSuper.ForEach(x => x.Movie = movies.Single(m => m.Name == "Dragon Ball Super"));
            episodes.Add(dragonBallSuper);

            #endregion

            #region Hyouka

            var hyouka = new List<Episode>
            {
                new Episode
                {
                    Name = "1",
                    Url = ConvertUrl("http://onecloud.media/file/26fc518515dc3ca1-db7febdb58deedb7")
                },
                new Episode
                {
                    Name = "2",
                    Url = ConvertUrl("http://onecloud.media/file/e1b004df9a8df5a0-0df8a001e3896919")
                },
                new Episode
                {
                    Name = "3",
                    Url = ConvertUrl("http://onecloud.media/file/f667d58321dfeb17-71fb9fc7d0f94890")
                },
                new Episode
                {
                    Name = "4",
                    Url = ConvertUrl("http://onecloud.media/file/c0f215734490f440-0c0946e9e56f3651")
                },
                new Episode
                {
                    Name = "5",
                    Url = ConvertUrl("http://onecloud.media/file/9be91ae358208e7f-b4fc916aace8e0df")
                },
                new Episode
                {
                    Name = "6",
                    Url = ConvertUrl("http://onecloud.media/file/ad7588ccf691ad38-4330a5c6eb2ae94c")
                },
                new Episode
                {
                    Name = "7",
                    Url = ConvertUrl("http://onecloud.media/file/78c6293e1d6cc2ae-6fd15321b5aeb226")
                },
                new Episode
                {
                    Name = "8",
                    Url = ConvertUrl("http://onecloud.media/file/6398e0d2bb11f37d-5c594bd00e178b90")
                },
                new Episode
                {
                    Name = "9",
                    Url = ConvertUrl("http://onecloud.media/file/1d783ab12ba8daeb-1a9a984c2f8460dc")
                },
                new Episode
                {
                    Name = "10",
                    Url = ConvertUrl("http://onecloud.media/file/c14f7cf8b2a10bbe-8992bb1ec8c9b763")
                },
                new Episode
                {
                    Name = "11",
                    Url = ConvertUrl("http://onecloud.media/file/8acb457edaa7c656-633b1d3de3815d35")
                },
                new Episode
                {
                    Name = "12",
                    Url = ConvertUrl("http://onecloud.media/file/60b2622f4c47986a-a9a91a46eddd6a4b")
                },
                new Episode
                {
                    Name = "13",
                    Url = ConvertUrl("http://onecloud.media/file/4edea0140e6893ed-94cfc3b2b121ac3f")
                },
                new Episode
                {
                    Name = "14",
                    Url = ConvertUrl("http://onecloud.media/file/53217e6489788cd3-20e3f565e3660848")
                },
                new Episode
                {
                    Name = "15",
                    Url = ConvertUrl("http://onecloud.media/file/e401841a2e722fe8-eb493dec71b0c1aa")
                },
                new Episode
                {
                    Name = "16",
                    Url = ConvertUrl("http://onecloud.media/file/05e192e272d59383-34fe5fc77bed5bc0")
                },
                new Episode
                {
                    Name = "17",
                    Url = ConvertUrl("http://onecloud.media/file/6ea5217fc531c31d-b0f962853e444e3f")
                },
                new Episode
                {
                    Name = "18",
                    Url = ConvertUrl("http://onecloud.media/file/d4e0e9baf89b7503-829c1d5bc031b7b2")
                },
                new Episode
                {
                    Name = "19",
                    Url = ConvertUrl("http://onecloud.media/file/fbdc4f90c94f001c-930ce0b8700b6eeb")
                },
                new Episode
                {
                    Name = "20",
                    Url = ConvertUrl("http://onecloud.media/file/bbedc3eade4280c6-27f019337a369ca1")
                },
                new Episode
                {
                    Name = "21",
                    Url = ConvertUrl("http://onecloud.media/file/93139da2b3c0b04d-690e03bedeb9fa1a")
                },
                new Episode
                {
                    Name = "22",
                    Url = ConvertUrl("http://onecloud.media/file/83fe6eb1cfa86aee-a41299e623eb0ca2")
                }
            };

            hyouka.ForEach(x => x.Movie = movies.Single(m => m.Name == "Hyouka"));
            episodes.Add(hyouka);

            #endregion

            #region Overlord

            var overlord = new List<Episode>
            {
                new Episode
                {
                    Name = "1",
                    Url = ConvertUrl("http://onecloud.media/file/b75f35bc1fb19586-3fe0e90a8d8d5107")
                },
                new Episode
                {
                    Name = "2",
                    Url = ConvertUrl("http://onecloud.media/file/9c685fc351d8667f-fc899c8659fa9f83")
                },
                new Episode
                {
                    Name = "3",
                    Url = ConvertUrl("http://onecloud.media/file/8caacac85868e9f5-aff437180c5d7d4f")
                },
                new Episode
                {
                    Name = "4",
                    Url = ConvertUrl("http://onecloud.media/file/ea38d87978b2c0fc-77ba1059061d1ce9")
                },
                new Episode
                {
                    Name = "5",
                    Url = ConvertUrl("http://onecloud.media/file/0fea0fdad6fd0ac1-10149fc84f889388")
                },
                new Episode
                {
                    Name = "6",
                    Url = ConvertUrl("http://onecloud.media/file/cbe38685ecaf9457-015b2e46f846e8d6")
                },
                new Episode
                {
                    Name = "7",
                    Url = ConvertUrl("http://onecloud.media/file/d85419852234a6e8-1e649a71918439fa")
                },
                new Episode
                {
                    Name = "8",
                    Url = ConvertUrl("http://onecloud.media/file/0a25421410a42c3d-c24eac2020339501")
                },
                new Episode
                {
                    Name = "9",
                    Url = ConvertUrl("http://onecloud.media/file/e6986e73b7915ef1-428c97a2b213a701")
                },
                new Episode
                {
                    Name = "10",
                    Url = ConvertUrl("http://onecloud.media/file/949de90969484086-236449cc3af3a640")
                },
                new Episode
                {
                    Name = "11",
                    Url = ConvertUrl("http://onecloud.media/file/87c132154887d7bb-87d9f19c7c5b38a3")
                },
                new Episode
                {
                    Name = "12",
                    Url = ConvertUrl("http://onecloud.media/file/59173da250a060bb-701bd95cee2e3e50")
                },
                new Episode
                {
                    Name = "13",
                    Url = ConvertUrl("http://onecloud.media/file/71b860a6eea72da8-cdca5477ce2bd1aa")
                }
            };

            overlord.ForEach(x => x.Movie = movies.Single(m => m.Name == "Overlord"));
            episodes.Add(overlord);

            #endregion

            #region Bakemonogatari

            var bakemonogatari = new List<Episode>
            {
                new Episode
                {
                    Name = "1",
                    Url = ConvertUrl("http://onecloud.media/file/cbbde4fc701e6e90-3b9345eab5da2878")
                },
                new Episode
                {
                    Name = "2",
                    Url = ConvertUrl("http://onecloud.media/file/f14750ff1ebc6f8a-3357d709fac73cb5")
                },
                new Episode
                {
                    Name = "3",
                    Url = ConvertUrl("http://onecloud.media/file/0d4d1750b188e53d-0d865282f85f85e6")
                },
                new Episode
                {
                    Name = "4",
                    Url = ConvertUrl("http://onecloud.media/file/0a35b2ded8137da3-ddf73d56bd1ebf89")
                },
                new Episode
                {
                    Name = "5",
                    Url = ConvertUrl("http://onecloud.media/file/25eda9af5fff2841-59902c373fdca382")
                },
                new Episode
                {
                    Name = "6",
                    Url = ConvertUrl("http://onecloud.media/file/5b846a141f2cde34-3515d769471f8771")
                },
                new Episode
                {
                    Name = "7",
                    Url = ConvertUrl("http://onecloud.media/file/9c786954b019175f-fe4e10f521d67842")
                },
                new Episode
                {
                    Name = "8",
                    Url = ConvertUrl("http://onecloud.media/file/86d3696efe7ecb52-598cd27bdd7fd50f")
                },
                new Episode
                {
                    Name = "9",
                    Url = ConvertUrl("http://onecloud.media/file/bac4a0b9eb475930-156508ee486ce374")
                },
                new Episode
                {
                    Name = "10",
                    Url = ConvertUrl("http://onecloud.media/file/9244110c0ccb1f6a-3fee7709146f9c6a")
                },
                new Episode
                {
                    Name = "11",
                    Url = ConvertUrl("http://onecloud.media/file/f5dea071a4bda83d-943adb467ac10ff4")
                },
                new Episode
                {
                    Name = "12",
                    Url = ConvertUrl("http://onecloud.media/file/88034ecbd827e93c-c0888e2ce926e46d")
                },
                new Episode
                {
                    Name = "13",
                    Url = ConvertUrl("http://onecloud.media/file/fff9b24a4936df4e-d67d20be3c9c58db")
                },
                new Episode
                {
                    Name = "14",
                    Url = ConvertUrl("http://onecloud.media/file/7c0d809289a9d414-fa217c46fc605c3a")
                },
                new Episode
                {
                    Name = "15",
                    Url = ConvertUrl("http://onecloud.media/file/b46da17f0af816c1-f92214d304f71cba")
                }
            };

            bakemonogatari.ForEach(x => x.Movie = movies.Single(m => m.Name == "Bakemonogatari"));
            episodes.Add(bakemonogatari);

            #endregion

            #region No Game No Life

            var noGameNoLife = new List<Episode>
            {
                new Episode
                {
                    Name = "1",
                    Url = ConvertUrl("http://onecloud.media/file/c524f2bf27340f8d-c8d54f15a587025d")
                },
                new Episode
                {
                    Name = "2",
                    Url = ConvertUrl("http://onecloud.media/file/07c364700e706cb1-5f34bf49cb52a3a9")
                },
                new Episode
                {
                    Name = "3",
                    Url = ConvertUrl("http://onecloud.media/file/40487533c7f17176-57a8a796e195497f")
                },
                new Episode
                {
                    Name = "4",
                    Url = ConvertUrl("http://onecloud.media/file/1926271b179e8784-78daab0e9b719769")
                },
                new Episode
                {
                    Name = "5",
                    Url = ConvertUrl("http://onecloud.media/file/511c8989dbf4591e-7f5b06e7c1079afd")
                },
                new Episode
                {
                    Name = "6",
                    Url = ConvertUrl("http://onecloud.media/file/937733c34c68f141-47d6cada7cd137c5")
                },
                new Episode
                {
                    Name = "7",
                    Url = ConvertUrl("http://onecloud.media/file/4d65e14ab7adeab7-3be923609d0ffd1f")
                },
                new Episode
                {
                    Name = "8",
                    Url = ConvertUrl("http://onecloud.media/file/12a9dc96c6ff1cf4-b6f3b79958461799")
                },
                new Episode
                {
                    Name = "9",
                    Url = ConvertUrl("http://onecloud.media/file/76f81a62158eafbd-219a757d7b07df9f")
                },
                new Episode
                {
                    Name = "10",
                    Url = ConvertUrl("http://onecloud.media/file/0fdd866486be880b-458d90108880bf5e")
                },
                new Episode
                {
                    Name = "11",
                    Url = ConvertUrl("http://onecloud.media/file/5998e92b8de735d3-7a287974afdac242")
                },
                new Episode
                {
                    Name = "12",
                    Url = ConvertUrl("http://onecloud.media/file/c505c141258aa003-4183a16d096603cc")
                }
            };

            noGameNoLife.ForEach(x => x.Movie = movies.Single(m => m.Name == "No Game No Life"));
            episodes.Add(noGameNoLife);

            #endregion

            #region Tonari No Totoro

            var totoro = new List<Episode>
            {
                new Episode
                {
                    Name = "1",
                    Url = ConvertUrl("http://onecloud.media/file/7fc0cb4ce9c0dc6d-29283c40dacabbef")
                }
            };

            totoro.ForEach(x => x.Movie = movies.Single(m => m.Name == "Tonari No Totoro"));
            episodes.Add(totoro);

            #endregion

            #region Hauru No Ugoku Shiro

            var howl = new List<Episode>
            {
                new Episode
                {
                    Name = "1",
                    Url = ""
                }
            };

            howl.ForEach(x => x.Movie = movies.Single(m => m.Name == "Hauru No Ugoku Shiro"));
            episodes.Add(howl);

            #endregion

            #region Akame Ga Kill

            var akame = new List<Episode>
            {
                new Episode
                {
                    Name = "1",
                    Url = ConvertUrl("http://onecloud.media/file/c585e4264ac79793-91b74772a5f8e1ce")
                },
                new Episode
                {
                    Name = "2",
                    Url = ConvertUrl("http://onecloud.media/file/9eeb32f8906f71ee-fa8d5eb3a44a66dc")
                },
                new Episode
                {
                    Name = "3",
                    Url = ConvertUrl("http://onecloud.media/file/35c66fac66198126-ff3f7f0662834763")
                },
                new Episode
                {
                    Name = "4",
                    Url = ConvertUrl("http://onecloud.media/file/40e221d07a9f9e8b-d70702fd4cc9c640")
                },
                new Episode
                {
                    Name = "5",
                    Url = ConvertUrl("http://onecloud.media/file/819ccafb264ad592-c1b4c15192978d24")
                },
                new Episode
                {
                    Name = "6",
                    Url = ConvertUrl("http://onecloud.media/file/ae87eb93592d93bc-3ce927f2b445eac2")
                },
                new Episode
                {
                    Name = "7",
                    Url = ConvertUrl("http://onecloud.media/file/41f0f9b45e8dd589-5a18c5d84dd0492f")
                },
                new Episode
                {
                    Name = "8",
                    Url = ConvertUrl("http://onecloud.media/file/4a4340b6dfca9140-7c5eb6ca72516fd6")
                }
            };

            akame.ForEach(x => x.Movie = movies.Single(m => m.Name == "Akame Ga Kill"));
            episodes.Add(akame);

            #endregion

            #region Shigatsu Wa Kimi No Uso

            var shigatsu = new List<Episode>
            {
                new Episode
                {
                    Name = "1",
                    Url = ConvertUrl("http://onecloud.media/file/2d87b427cea48a5c-e752c9b3a000be79")
                },
                new Episode
                {
                    Name = "2",
                    Url = ConvertUrl("http://onecloud.media/file/54ae7d914d90a5ae-bda52bb5f98c9485")
                },
                new Episode
                {
                    Name = "3",
                    Url = ConvertUrl("http://onecloud.media/file/50e12ed0664e5a37-07b524568681e1c3")
                },
                new Episode
                {
                    Name = "4",
                    Url = ConvertUrl("http://onecloud.media/file/cb979b53b5a6f4ca-87fd347a4579234d")
                },
                new Episode
                {
                    Name = "5",
                    Url = ConvertUrl("http://onecloud.media/file/6cebd80d0ba11201-69e90355f6d95354")
                },
                new Episode
                {
                    Name = "6",
                    Url = ConvertUrl("http://onecloud.media/file/db84a1c9e583c940-feb643536bdab181")
                }
            };

            shigatsu.ForEach(x => x.Movie = movies.Single(m => m.Name == "Shigatsu Wa Kimi No Uso"));
            episodes.Add(shigatsu);

            #endregion

            #region Kill La Kill

            var killLaKill = new List<Episode>
            {
                new Episode
                {
                    Name = "1",
                    Url = ConvertUrl("http://onecloud.media/file/a37370f34963364d-1859d14762e6ff2d")
                },
                new Episode
                {
                    Name = "2",
                    Url = ConvertUrl("http://onecloud.media/file/af0c151c6ae6a01d-1801276d0f65193d")
                },
                new Episode
                {
                    Name = "3",
                    Url = ConvertUrl("http://onecloud.media/file/8036a2a6a5a277fb-ad5bbb34015fc812")
                },
                new Episode
                {
                    Name = "4",
                    Url = ConvertUrl("http://onecloud.media/file/e0b86aa4c3cecff9-2d7e4ba3c3dabc34")
                },
                new Episode
                {
                    Name = "5",
                    Url = ConvertUrl("http://onecloud.media/file/7bad38f3336e71ba-13fb441a7bb4de3b")
                },
                new Episode
                {
                    Name = "6",
                    Url = ConvertUrl("http://onecloud.media/file/b8ec428a0d989ccc-a6a459847355c5d4")
                }
            };

            killLaKill.ForEach(x => x.Movie = movies.Single(m => m.Name == "Kill La Kill"));
            episodes.Add(killLaKill);

            #endregion

            #region One Piece

            var onePiece = new List<Episode>
            {
                new Episode
                {
                    Name = "1",
                    Url = ConvertUrl("http://onecloud.media/file/78816a0d052736ff-fc148cc9d5b621f6")
                },
                new Episode
                {
                    Name = "2",
                    Url = ConvertUrl("http://onecloud.media/file/6b47cdc90159efb8-0d832a559aa48640")
                },
                new Episode
                {
                    Name = "3",
                    Url = ConvertUrl("http://onecloud.media/file/725b8e7aa141e9a6-8d675c43fc510e12")
                },
                new Episode
                {
                    Name = "4",
                    Url = ConvertUrl("http://onecloud.media/file/b363d71a8d5513d2-e5b701168527b7b0")
                },
                new Episode
                {
                    Name = "5",
                    Url = ConvertUrl("http://onecloud.media/file/9eed65eae28593c7-8f04a28f0db7496e")
                },
                new Episode
                {
                    Name = "6",
                    Url = ConvertUrl("http://onecloud.media/file/335394d82a40297b-e7cd4181c79dc06a")
                },
                new Episode
                {
                    Name = "7",
                    Url = ConvertUrl("http://onecloud.media/file/add776810dfe930e-39657c8d7ca82081")
                },
                new Episode
                {
                    Name = "8",
                    Url = ConvertUrl("http://onecloud.media/file/a62bbf7734470478-c537c1d38c245c46")
                },
                new Episode
                {
                    Name = "9",
                    Url = ConvertUrl("http://onecloud.media/file/03dc437314a3fd18-92596afed4274280")
                },
                new Episode
                {
                    Name = "10",
                    Url = ConvertUrl("http://onecloud.media/file/d54037e4c29f30b5-d96c7c0240629d3c")
                },
                new Episode
                {
                    Name = "11",
                    Url = ConvertUrl("http://onecloud.media/file/b1bc124b2ca3fe92-37eab44aef61d140")
                },
                new Episode
                {
                    Name = "12",
                    Url = ConvertUrl("http://onecloud.media/file/204ec80a44523a89-a3007247a81edf80")
                },
                new Episode
                {
                    Name = "13",
                    Url = ConvertUrl("http://onecloud.media/file/61281cd372629546-6e848a2a78cf06e1")
                },
                new Episode
                {
                    Name = "14",
                    Url = ConvertUrl("http://onecloud.media/file/134dee1e75fa834c-86f9ade177e6d466")
                },
                new Episode
                {
                    Name = "15",
                    Url = ConvertUrl("http://onecloud.media/file/48763a3efa57a1b0-6cb59158093e5518")
                },
                new Episode
                {
                    Name = "16",
                    Url = ConvertUrl("http://onecloud.media/file/2f36ddd9a5cbf75a-176bc6de780cc4a8")
                },
                new Episode
                {
                    Name = "17",
                    Url = ConvertUrl("http://onecloud.media/file/11cfe87b47905b02-a126fb6e777e7f83")
                },
                new Episode
                {
                    Name = "18",
                    Url = ConvertUrl("http://onecloud.media/file/abb85f211fb25028-0e5586a3c5a64647")
                },
                new Episode
                {
                    Name = "19",
                    Url = ConvertUrl("http://onecloud.media/file/cf39e24ba72d3f4f-ceb4633ed6ec41ff")
                },
                new Episode
                {
                    Name = "20",
                    Url = ConvertUrl("http://onecloud.media/file/fc0f7c934e7a8462-f808312ac88d1c4a")
                }
            };

            onePiece.ForEach(x => x.Movie = movies.Single(m => m.Name == "One Piece"));
            episodes.Add(onePiece);

            #endregion

            #region Accel World

            var accelWorld = new List<Episode>
            {
                new Episode
                {
                    Name = "1",
                    Url = ConvertUrl("http://onecloud.media/file/9a1f921fabaf4d24-0b0c7e463048bacc")
                },
                new Episode
                {
                    Name = "2",
                    Url = ConvertUrl("http://onecloud.media/file/b90b858a1127c149-d9034999870e0f0c")
                },
                new Episode
                {
                    Name = "3",
                    Url = ConvertUrl("http://onecloud.media/file/4e7bfcdee54bd960-e45b1d79d7ec2432")
                },
                new Episode
                {
                    Name = "4",
                    Url = ConvertUrl("http://onecloud.media/file/5e5d3a99f1e805d2-0c6ae3445fa0b8ec")
                },
                new Episode
                {
                    Name = "5",
                    Url = ConvertUrl("http://onecloud.media/file/3f2486b8c6c9bbd2-ffe9b8a318d438b7")
                },
                new Episode
                {
                    Name = "6",
                    Url = ConvertUrl("http://onecloud.media/file/27e6b2e1d06b572c-a9bbc04a5ebee374")
                }
            };

            accelWorld.ForEach(x => x.Movie = movies.Single(m => m.Name == "Accel World"));
            episodes.Add(accelWorld);

            #endregion

            #region Kyoukai No Kanata

            var kyoukaiNoKanata = new List<Episode>
            {
                new Episode
                {
                    Name = "1",
                    Url = ConvertUrl("http://onecloud.media/file/63869fc6ad4a1469-b746d05177026b62")
                },
                new Episode
                {
                    Name = "2",
                    Url = ConvertUrl("http://onecloud.media/file/af396b09cf9d643a-4fdb74064b2586dc")
                },
                new Episode
                {
                    Name = "3",
                    Url = ConvertUrl("http://onecloud.media/file/ce21fbf1cb8323bc-459535ef5a06b741")
                },
                new Episode
                {
                    Name = "4",
                    Url = ConvertUrl("http://onecloud.media/file/e658223274b53c8c-f6157376eb3e5221")
                },
                new Episode
                {
                    Name = "5",
                    Url = ConvertUrl("http://onecloud.media/file/f54e1bf23004b5ae-f9be8ccc2debd99a")
                },
                new Episode
                {
                    Name = "6",
                    Url = ConvertUrl("http://onecloud.media/file/accab70e9f863ab4-820bd904a58dbe8f")
                }
            };

            kyoukaiNoKanata.ForEach(x => x.Movie = movies.Single(m => m.Name == "Kyoukai No Kanata"));
            episodes.Add(kyoukaiNoKanata);

            #endregion

            #region Ao No Exorcist

            var aoNoExorcist = new List<Episode>
            {
                new Episode
                {
                    Name = "1",
                    Url = ConvertUrl("http://onecloud.media/file/5d79c081badea2cd-8d4bd590c18ed127")
                },
                new Episode
                {
                    Name = "2",
                    Url = ConvertUrl("http://onecloud.media/file/57848743d64b34b3-a6778b64d239df44")
                },
                new Episode
                {
                    Name = "3",
                    Url = ConvertUrl("http://onecloud.media/file/aab81e39733c7890-e09dee75d5a6dc24")
                },
                new Episode
                {
                    Name = "4",
                    Url = ConvertUrl("http://onecloud.media/file/fe24a29f950ffa28-7c190a87c53201a9")
                },
                new Episode
                {
                    Name = "5",
                    Url = ConvertUrl("http://onecloud.media/file/f99d39315aea0760-a713a4f7f800276c")
                },
                new Episode
                {
                    Name = "6",
                    Url = ConvertUrl("http://onecloud.media/file/105f75b8d49b4e79-67f7c33b43efb99d")
                }
            };

            aoNoExorcist.ForEach(x => x.Movie = movies.Single(m => m.Name == "Ao No Exorcist"));
            episodes.Add(aoNoExorcist);

            #endregion

            #region Tokyo Ghoul

            var tokyoGhoul = new List<Episode>
            {
                new Episode
                {
                    Name = "1",
                    Url = ConvertUrl("http://onecloud.media/file/41f11a262d9789ae-304d682a9dfe6a39")
                },
                new Episode
                {
                    Name = "2",
                    Url = ConvertUrl("http://onecloud.media/file/3f10efea81fbf06a-1006b3fc2babc95f")
                },
                new Episode
                {
                    Name = "3",
                    Url = ConvertUrl("http://onecloud.media/file/9aa0df10c74f7ad2-687260866d7223fb")
                },
                new Episode
                {
                    Name = "4",
                    Url = ConvertUrl("http://onecloud.media/file/8e1f8003abb194b9-5ecd2c4f11e3b613")
                },
                new Episode
                {
                    Name = "5",
                    Url = ConvertUrl("http://onecloud.media/file/8950d632d814a402-de155de7ed5459b8")
                },
                new Episode
                {
                    Name = "6",
                    Url = ConvertUrl("http://onecloud.media/file/6a7e572aca1387ed-7ec3b23c2978ed39")
                }
            };

            tokyoGhoul.ForEach(x => x.Movie = movies.Single(m => m.Name == "Tokyo Ghoul"));
            episodes.Add(tokyoGhoul);

            #endregion

            #endregion

            var tasks = new List<Task>
            {
                context.Genres.AddRangeAsync(genres.Values),
                context.Movies.AddRangeAsync(movies)
            };
            episodes.ForEach(x => tasks.Add(context.Episodes.AddRangeAsync(x)));

            await Task.WhenAll(tasks);
            await context.SaveChangesAsync();

            await AccountSeeder.InitializeAsync(app);
            await AdvertisementSeeder.InitializeAsync(app);
        }
    }
}