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

            await AccountSeeder.InitializeAsync(app);

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
                    Views = 2000,
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
                    Views = 2000,
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
                    Views = 1000,
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
                    Views = 3000,
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
                    Views = 5000,
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
                    Views = 6000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[drama]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[schoolLife]},
                        new GenreMovie {Genre = genres[superNatural]}
                    },
                    Status = Status.Completed,
                    Description =
                        "Câu chuyện về phép màu và tình yêu xoay xung quanh Mitsuha và Taki. Mitsuha là một cô bé học sinh cấp 3 sống tại một vùng nông thôn nằm rúc sâu trong núi. Cha cô là thị trưởng và rất ít khi ở nhà, bản thân cô sống với đứa em gái đang học tiểu học và bà nội."
                },
                new Movie
                {
                    Name = "Mahouka Koukou No Rettousei",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/12/27/[animevsub.com]-the-irregular-at-magic-high-school_3d4c311ff614980687780aea8a35bfe9.jpg",
                    Release = new DateTime(2014, 1, 1),
                    Views = 3500,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[magic]},
                        new GenreMovie {Genre = genres[romance]},
                        new GenreMovie {Genre = genres[sciFi]},
                        new GenreMovie {Genre = genres[schoolLife]},
                        new GenreMovie {Genre = genres[superNatural]}
                    },
                    Status = Status.Completed,
                    Description =
                        "Phép thuật không phải là sản phẩm của huyền thoại hay chuyện cổ tích, mà thay vào đó đã trở thành công nghệ thực tiễn từ một thời mà không ai biết được. Năng lực siêu nhiên đã trở thành một công nghệ được hệ thống hóa thông qua phép thuật, trong khi đó phép thuật thì đã trở thành một kỹ năng chuyên môn."
                },
                new Movie
                {
                    Name = "Akame Ga Kill",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/03/25/[animevsub.com]-akame-ga-kiru_6efb0d8d0bd0e5707185d2c15d043786.jpg",
                    Release = new DateTime(2014, 1, 1),
                    Views = 2000,
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
                    Status = Status.Completed,
                    Description =
                        "Tatsumi là một kiếm sĩ, đến thủ đô để tìm cách làm giàu cho ngôi làng nghèo khó của mình và trở thành nạn nhân của một vụ lừa tình lột tiền. Sau đó, cậu được một tiểu thư quý tộc tên là Aria cho tá túc. Đêm tiếp theo, nhóm sát thủ Night Raid do Akame chỉ huy tấn công vào tư dinh của Aria."
                },
                new Movie
                {
                    Name = "Detective Conan",
                    Image =
                        "https://images2-focus-opensocial.googleusercontent.com/gadgets/proxy?container=focus&gadget=a&no_expand=1&refresh=604800&url=http://img.animevsub.com/images/2016/04/18/[animevsub.com]-detective-conan_b96803c31fea61e705aa89184b092899.jpg",
                    Release = new DateTime(1996, 1, 1),
                    Views = 10000,
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
                    Views = 15000,
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
                    Views = 2000,
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
                    Views = 5000,
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
                    Views = 6000,
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
                    Views = 5000,
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
                    Views = 2000,
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
                    Views = 2000,
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
                    Views = 2000,
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
                    Views = 2000,
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
                    Views = 2000,
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
                    Views = 5000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
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
                    Views = 4000,
                    GenreMovies = new List<GenreMovie>
                    {
                        new GenreMovie {Genre = genres[comedy]},
                        new GenreMovie {Genre = genres[ecchi]},
                        new GenreMovie {Genre = genres[romance]}
                    },
                    Description =
                        "Nekopara là gì?Tại sao, đây là con mèo của thiên đường. Kashou Minazuki, một hàng dài người Nhật chuyển ra, con trai của nhà sản xuất kẹo tự mở La Circus như một tiệm bánh ngọt. Nhưng trong di chuyển, ẩn trong đồ của hắn đều ở Catgirls (Cat), hay Carat và vani, gia đình này đã tăng.Khi hắn đang cố đưa họ đi, họ cầu xin cho đến khi hắn bây giờ họ đã mở rạp xiếc. Los Angeles cùng nhau. Hai nekos ai thực sự yêu chủ nhân của chúng trong họ nhất thỉnh thoảng thất bại... Chân thành hài, mở cửa!"
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
                    Url = ConvertUrl("http://onecloud.media/file/43b9a4368d3e7099-e51029d2a7731cb2")
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
                }
            };

            mahouka.ForEach(x => x.Movie = movies.Single(m => m.Name == "Mahouka Koukou No Rettousei"));
            episodes.Add(mahouka);

            #endregion

            #endregion

            await context.Genres.AddRangeAsync(genres.Values);
            await context.Movies.AddRangeAsync(movies);
            episodes.ForEach(async x => await context.Episodes.AddRangeAsync(x));
            await context.SaveChangesAsync();
        }
    }
}