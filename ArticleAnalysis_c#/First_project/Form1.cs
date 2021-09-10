using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using hap = HtmlAgilityPack;
namespace First_project
{
    public partial class Form1 : Form
    {
        public SqlConnection connection;
        public SqlDataReader sd;
        public String sql;
        public SqlCommand sqlcomm = new SqlCommand();
        public String connstr = "Server=LAPTOP-RIAEOERK;"
                                + "database=first_DB;"
                                + "uid=qwe113;"
                                + "pwd=2708;";
        public string url;
        public string code;
        public double fluctuation_point; // 해당종목 등락률 
        public double market_fluctuation_point; // 마켓 등락률
        public string[] market_type = { "KOSPI", "KOSDAQ", "KONEX" }; // 시장구분 1:코스피 2:코스닥 3:코넥스
        int type = -1; // 시장인덱스
        public Form1()
        {
            InitializeComponent();
            TestDbConnect();
        }
        
        public void TestDbConnect() // DB연결
        {
            try
            {
                // Build connection string
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "LAPTOP-RIAEOERK";   // update me
                builder.UserID = "qwe113";              // update me
                builder.Password = "2708";      // update me
                builder.InitialCatalog = "first_DB";

                // Connect to SQL
                Lab01.Text = "Connecting to SQL Server ... ";
                using (connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    Lab01.Text = "Done.";
                }
            }
            catch (SqlException e)
            {
                Lab01.Text = e.ToString();
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Btn_Analysis_Click(object sender, EventArgs e)
        {
            url = Tb_URL.Text; // 텍박의 url 가져옴
            code = "No"; // 종목코드
            bool find_name = false;
            String name = "";
            hap.HtmlWeb web = new hap.HtmlWeb();
            hap.HtmlDocument htmldoc = web.Load(url);
            hap.HtmlNode titlenode = htmldoc.DocumentNode.SelectSingleNode("//title");
            hap.HtmlNode timenode = htmldoc.DocumentNode.SelectSingleNode("//*[@id='newsView']/div[1]/div/div[2]/span[1]");
            String title = titlenode.InnerText; // 기사 제목 추출 /html/head/meta[32]
            String article_time = timenode.InnerText; // 기사 시간 추출
            Lab02.Text = title; // 제목
            Lab03.Text = article_time; // 시간
            

            connection.ConnectionString = connstr;
            connection.Open();
            //종목명추출
            for (int i = 0; i < 3; i++)
            {
                sql = "SELECT name,code FROM " + market_type[i] + " order by LEN(name)desc";
                sqlcomm.CommandText = sql;
                sqlcomm.Connection = connection;
                sd = sqlcomm.ExecuteReader();
                find_name = false;
                while (sd.Read())
                {
                    name = sd[0].ToString();
                    if (title.Contains(name))
                    {
                        find_name = true;
                        title = title.Replace(name, ""); // 추출한 이름을 삭제
                        code = sd[1].ToString();
                        type = i;// 시장인덱스저장
                        i = 3;
                        break;
                    }
                }
            }
            if (find_name)
            {
                Lab04.Text = name; // 종목명
                Lab10.Text = market_type[type]; // 시장
            }
            else
                Lab04.Text = "업는데용";

            cal_fluctuation(article_time, code); // 종목등락률
            cal_market_fluctuation(article_time, type); // 시장등락률
            // 1페이지 년 - 년, 월 - 월
            // 21년 3월 20년 15월 20년 11월 4월 4 + (4*0.5)
            // 추출끝
            // 전에 추출한 시간을 이용해 그날의 주가 변동을 저장
            // 키워드와 주가 변동 내용을 테이블에 저장
            // 결과 뷰를 띄운다
            /*Hide();
            Analysis_result ar = new Analysis_result();
            ar.Show();*/
        }
        public void cal_fluctuation(string article_time, string code) //변동률 계산
        {
            bool is_today_article = false;
            // 만약 3시반이후에 개시된 기사라면 다음날 주가를 계산해야한다 tr을 하나줄이고
            // tr[3]이라면 current_page를 하나줄이고 tr[15]를 보고 계산한다
            double[] fluctuation_point = { -100.0, -100.0, -100.0 }; // 해당종목 등락률 
            int[] tr = { 3, 4, 5, 6, 7, 11, 12, 13, 14, 15 }; int idx = 0;
            bool end_flag = true;
            int current_page = 1;

            hap.HtmlWeb web = new hap.HtmlWeb();
            url = "https://finance.naver.com/item/sise_day.nhn?code=" + code + "&page=1";
            hap.HtmlDocument htmldoc = web.Load(url);
            // 가장 최근날짜를 가져옴
            string[] day_and_time = article_time.Split(' ');
            string[] article_timearr = day_and_time[1].Split('.'); // 년 월 일 나누기
            // 등락률 첫페이지 가져옴
            hap.HtmlNode recent_time = htmldoc.DocumentNode.SelectSingleNode("/html/body/table[1]/tr[3]/td[1]/span");
            // 얘도 년월일 나눔
            string[] recent_timearr = recent_time.InnerText.Split('.');
            int year_gap = int.Parse(recent_timearr[1]) - int.Parse(article_timearr[0]); // 연도차
            int month_gap = year_gap * 12 + int.Parse(recent_timearr[1]) - int.Parse(article_timearr[1]); // 월차
            if (month_gap > 1) // 2달이상 차이날때만 스타트 페이지 계산
            {
                current_page = (int)(month_gap * 1.5);// 스타트 페이지 계산
            }
            Console.WriteLine("CP : "+current_page + " MG : "+month_gap);
            Console.WriteLine(day_and_time[2]);
            while (end_flag)
            {
                
                url = "https://finance.naver.com/item/sise_day.nhn?code=" + code + "&page=" + current_page;
                htmldoc = web.Load(url);
                recent_time = htmldoc.DocumentNode.SelectSingleNode("/html/body/table[1]/tr[3]/td[1]/span");
                //년월일 나눔
                recent_timearr = recent_time.InnerText.Split('.');
                year_gap = int.Parse(recent_timearr[0]) - int.Parse(article_timearr[0]); // 연도차
                month_gap = year_gap * 12 + int.Parse(recent_timearr[1]) - int.Parse(article_timearr[1]); // 월차
                if (month_gap == 0) // 기사 개시 월이랑 같다
                {
                    int day_gap = int.Parse(recent_timearr[2]) - int.Parse(article_timearr[2]); // 일차
                    if (day_gap > 0) // 일수가 크다면
                    {
                        current_page++;
                    }
                    else if(day_gap < 0) // 작다면
                    {
                        current_page--; // 이전페이지에 있겠지
                        end_flag = false; // 페이지를 찾았으니 나온다
                    }
                    else // 같다면
                    {
                        end_flag = false; // 페이지를 찾았으니 나온다
                    }
                }
                else if(month_gap > 0) // 기사 개시 월보다 크다
                {
                    current_page++;
                }
                else // 기사 개시 월보다 작다?
                {
                    current_page--; // 이전페이지에 있겠지
                    end_flag = false; // 페이지를 찾았으니 나온다
                }
            }
            end_flag = true;
            while (end_flag) // 종목전용 그 페이지에서 같은 날짜인 열을 찾는다 + 등락율계산
            {
                //현재페이지를 받는다
                url = "https://finance.naver.com/item/sise_day.nhn?code=" + code + "&page=" + current_page;
                htmldoc = web.Load(url);
                //한열씩 찾는다
                recent_time = htmldoc.DocumentNode.SelectSingleNode("/html/body/table[1]/tr[" + tr[idx] + "]/td[1]/span");
                Console.WriteLine("recent : "+recent_time.InnerText);
                Console.WriteLine("article : " + day_and_time[1]);
                if(recent_time.InnerText == day_and_time[1]) // 같은날짜 열 확인
                {
                    day_and_time[2] = day_and_time[2].Replace(":","");
                    if(int.Parse(day_and_time[2]) >= 1530) // 장마감 이후 기사개시
                    {
                        idx--; // 다음날 가격으로 확인
                        if(idx == -1) // tr[3]이라면
                        {
                            current_page--; // 이전 페이지으로 넘어간다
                            url = "https://finance.naver.com/item/sise_day.nhn?code=" + code + "&page=" + current_page;
                            htmldoc = web.Load(url);
                            idx = 9; // 가장아래쪽을 가리킴
                        }
                        if(current_page == 0) // 여기에 갔다면 당일 장마감 이후 기사라는뜻
                        {
                            is_today_article = true;
                            break; // 더 볼 필요 없어
                        }
                    }
                    //시가와 등락계산
                    int start_price = int.Parse(htmldoc.DocumentNode.SelectSingleNode("/html/body/table[1]/tr[" + tr[idx] + "]/td[4]/span").InnerText.Replace(",", ""));
                    int day_price = int.Parse(htmldoc.DocumentNode.SelectSingleNode("/html/body/table[1]/tr[" + tr[idx] + "]/td[2]/span").InnerText.Replace(",", ""));
                    fluctuation_point[0] = (double)(day_price-start_price) / (double)start_price * 100.0; //당일 등락률 계산
                    Lab07.Text = string.Format("{0:0.#}%", fluctuation_point[0]);
                    if (current_page > 1 || idx >= 4) // 5거래일 등락률 계산
                    {
                        //5거래일 주가 계산
                        if (idx < 4)
                        {
                            idx = 10 + (idx - 4);
                            url = "https://finance.naver.com/item/sise_day.nhn?code=" + code + "&page=" + (current_page-1);
                            htmldoc = web.Load(url); //이전페이지로드
                        }
                        else
                            idx = idx - 4;
                        int week_price = int.Parse(htmldoc.DocumentNode.SelectSingleNode("/html/body/table[1]/tr[" + tr[idx] + "]/td[2]/span").InnerText.Replace(",", "")); // 5거래일 종가
                        Console.WriteLine(week_price + " " + start_price);
                        fluctuation_point[1] = (double)(week_price - start_price) / (double)start_price * 100.0; //5거래일 등락률 계산
                        Lab08.Text = string.Format("{0:0.#}%", fluctuation_point[1]);
                        idx = idx + 4; //idx를 돌려놓는다
                        if (idx > 9)
                        {
                            idx = idx - 10;
                            url = "https://finance.naver.com/sise/sise_index_day.nhn?code=" + market_type[type] + "&page=" + current_page;
                            htmldoc = web.Load(url); //다음페이지로드
                        }
                        if (current_page >= 3) // 20거래일 등락률 계산
                        {
                            url = "https://finance.naver.com/item/sise_day.nhn?code=" + code + "&page=" + (current_page - 2);
                            htmldoc = web.Load(url); //2페이지전로드
                            int month_price = int.Parse(htmldoc.DocumentNode.SelectSingleNode("/html/body/table[1]/tr[" + tr[idx] + "]/td[2]/span").InnerText.Replace(",", "")); // 20거래일 종가
                            fluctuation_point[2] = (double)(month_price - start_price) / (double)start_price * 100.0; //20거래일 등락률 계산
                        }
                        end_flag = false;
                    }
                    else
                    {
                        end_flag = false;
                    }
                }
                else
                {
                    idx++;
                }
            }
            Lab09.Text = string.Format("{0:0.#}%", fluctuation_point[2]);
            if (is_today_article)
            {
                Console.WriteLine("내일 오도록하자");
            }
            //코스피,코스닥 구분을 위해 테이블을 나눠야 할 것 같다
        }

        public void cal_market_fluctuation(string article_time, int type)
        {
            bool is_today_article = false;
            double[] fluctuation_point = { -100.0, -100.0, -100.0 }; // 해당종목 등락률 
            int[] tr = { 3, 4, 5, 10, 11, 12 }; int idx = 0;
            bool end_flag = true;
            int current_page = 0;

            hap.HtmlWeb web = new hap.HtmlWeb();
            url = "https://finance.naver.com/sise/sise_index_day.nhn?code=" + market_type[type] + "&page=1";
            hap.HtmlDocument htmldoc = web.Load(url);
            // 가장 최근날짜를 가져옴
            string[] day_and_time = article_time.Split(' ');
            string[] article_timearr = day_and_time[1].Split('.'); // 년 월 일 나누기
            // 등락률 첫페이지 가져옴
            hap.HtmlNode recent_time = htmldoc.DocumentNode.SelectSingleNode("/html/body/div/table[1]/tr[3]/td[1]");
            // 얘도 년월일 나눔
            string[] recent_timearr = recent_time.InnerText.Split('.');
            int year_gap = int.Parse(recent_timearr[0]) - int.Parse(article_timearr[0]); // 연도차
            int month_gap = year_gap * 12 + int.Parse(recent_timearr[1]) - int.Parse(article_timearr[1]); // 월차
            if (month_gap > 1) // 2달이상 차이날때만 스타트 페이지 계산
            {
                current_page = (int)(month_gap * 2);// 스타트 페이지 계산
            }

            Console.WriteLine(day_and_time[1]);
            while (end_flag)
            {
                url = "https://finance.naver.com/sise/sise_index_day.nhn?code=" + market_type[type] + "&page=" + current_page;
                htmldoc = web.Load(url);
                recent_time = htmldoc.DocumentNode.SelectSingleNode("/html/body/div/table[1]/tr[3]/td[1]");
                //년월일 나눔
                recent_timearr = recent_time.InnerText.Split('.');
                year_gap = int.Parse(recent_timearr[0]) - int.Parse(article_timearr[0]); // 연도차
                month_gap = year_gap * 12 + int.Parse(recent_timearr[1]) - int.Parse(article_timearr[1]); // 월차
                if (month_gap == 0) // 기사 개시 월이랑 같다
                {
                    int day_gap = int.Parse(recent_timearr[2]) - int.Parse(article_timearr[2]); // 일차
                    if (day_gap > 0) // 일수가 크다면
                    {
                        current_page++;
                    }
                    else if (day_gap < 0) // 작다면
                    {
                        current_page--; // 이전페이지에 있겠지
                        end_flag = false; // 페이지를 찾았으니 나온다
                    }
                    else // 같다면
                    {
                        end_flag = false; // 페이지를 찾았으니 나온다
                    }
                }
                else if (month_gap > 0) // 기사 개시 월보다 크다
                {
                    current_page++;
                }
                else // 기사 개시 월보다 작다?
                {
                    current_page--; // 이전페이지에 있겠지
                    end_flag = false; // 페이지를 찾았으니 나온다
                }
            }
            end_flag = true;
            while (end_flag) // 종목전용 그 페이지에서 같은 날짜인 열을 찾는다 + 등락율계산
            {
                //현재페이지를 받는다
                url = "https://finance.naver.com/sise/sise_index_day.nhn?code=" + market_type[type] + "&page=" + current_page;
                htmldoc = web.Load(url);
                //한열씩 찾는다
                recent_time = htmldoc.DocumentNode.SelectSingleNode("/html/body/div/table[1]/tr[" + tr[idx] + "]/td[1]");
                Console.WriteLine("recent : " + recent_time.InnerText);
                Console.WriteLine("article : " + day_and_time[1]);
                if (recent_time.InnerText == day_and_time[1]) // 같은날짜 열 확인
                {
                    day_and_time[2] = day_and_time[2].Replace(":", "");
                    if (int.Parse(day_and_time[2]) < 1530) // 반대로 장중 기사 개시
                    { // 전날 종가와 오늘 종가를 비교해야함
                        idx++; // 전날 가격으로 확인
                        if (idx == 6) // tr[12]이라면
                        {
                            current_page++; // 다음 페이지으로 넘어간다
                            idx = 0; // 가장위쪽을 가리킴
                            url = "https://finance.naver.com/sise/sise_index_day.nhn?code=" + market_type[type] + "&page=" + current_page;
                            htmldoc = web.Load(url); // 페이지 로딩
                        }
                    }
                    else if (current_page==1 && idx == 0) // 장마감 이후 기사 + 오늘기사
                    {
                        is_today_article = true;
                        break; // 더볼거없다
                    }
                    //시가와 등락계산
                    double start_price = double.Parse(htmldoc.DocumentNode.SelectSingleNode("/html/body/div/table[1]/tr[" + tr[idx] + "]/td[2]").InnerText.Replace(",", ""));
                    idx--; // 다음날 가격 인덱스
                    if(idx == -1) // 이전페이지 가야지
                    {
                        idx = 5; // 가장아래쪽을 가리킴
                        url = "https://finance.naver.com/sise/sise_index_day.nhn?code=" + market_type[type] + "&page=" + (current_page-1);
                        htmldoc = web.Load(url); // 페이지 로딩
                    }
                    double day_price = double.Parse(htmldoc.DocumentNode.SelectSingleNode("/html/body/div/table[1]/tr[" + tr[idx] + "]/td[2]").InnerText.Replace(",", ""));
                    fluctuation_point[0] = (double)(day_price - start_price) / (double)start_price * 100.0; //당일 등락률 계산
                    Lab11.Text = string.Format("{0:0.#}%", fluctuation_point[0]);
                    if (current_page > 1 || idx >= 4) // 5거래일 등락률 계산
                    {
                        //5거래일 주가 계산
                        if (idx < 4)
                        {
                            idx = 6 + (idx - 4);
                            url = "https://finance.naver.com/sise/sise_index_day.nhn?code=" + market_type[type] + "&page=" + (current_page - 1);
                            htmldoc = web.Load(url); //이전페이지로드
                        }
                        else
                            idx = idx - 4;
                        double week_price = double.Parse(htmldoc.DocumentNode.SelectSingleNode("/html/body/div/table[1]/tr[" + tr[idx] + "]/td[2]").InnerText.Replace(",", "")); // 5거래일 종가
                        Console.WriteLine(week_price + " " + start_price);
                        fluctuation_point[1] = (double)(week_price - start_price) / (double)start_price * 100.0; //5거래일 등락률 계산
                        Lab12.Text = string.Format("{0:0.#}%", fluctuation_point[1]);
                        idx = idx + 4; //idx를 돌려놓는다
                        if (idx > 5) //인덱스 초과
                        {
                            idx = idx - 6;
                            url = "https://finance.naver.com/sise/sise_index_day.nhn?code=" + market_type[type] + "&page=" + current_page;
                            htmldoc = web.Load(url); //이전페이지로드
                        }
                        
                        if (current_page > 3 || (current_page == 3 && idx>0)) // 20거래일 등락률 계산
                        {
                            if (idx == 0) // 이러면 세페이지 전으로
                            {
                                url = "https://finance.naver.com/sise/sise_index_day.nhn?code=" + market_type[type] + "&page=" + (current_page - 3);
                                idx = 5;
                            }
                            else
                            {
                                url = "https://finance.naver.com/sise/sise_index_day.nhn?code=" + market_type[type] + "&page=" + (current_page - 2);
                                idx--;
                            }
                            htmldoc = web.Load(url); //2페이지전로드
                            double month_price = double.Parse(htmldoc.DocumentNode.SelectSingleNode("/html/body/div/table[1]/tr[" + tr[idx] + "]/td[2]").InnerText.Replace(",", "")); // 20거래일 종가
                            fluctuation_point[2] = (double)(month_price - start_price) / (double)start_price * 100.0; //20거래일 등락률 계산
                        }
                        end_flag = false;
                    }
                    else
                    {
                        end_flag = false;
                    }
                }
                else
                {
                    idx++;
                }
            }
            Lab13.Text = string.Format("{0:0.#}%", fluctuation_point[2]);
            if(is_today_article)
                Console.WriteLine("내일오세요");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}