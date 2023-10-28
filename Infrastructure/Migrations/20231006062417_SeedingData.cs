using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductBrands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ZUES" },
                    { 2, "YOHE" },
                    { 3, "TORC" },
                    { 4, "SUNDA" },
                    { 5, "ROYAL" },
                    { 6, "ROC" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "MuXeDap" },
                    { 2, "FullFace" },
                    { 3, "BaPhanTu" },
                    { 4, "GangTay" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "PictureUrl", "Price", "ProductBrandId", "ProductTypeId" },
                values: new object[,]
                {
                    { 1, "Zeus LH01 la san pham mu bao hiem xe dap cua cong ty Long Huei – Nha san xuat mu bao hiem voi hon 30 nam kinh nghiem", "", "images/products/muxedap-zues1.png", 200m, 1, 1 },
                    { 2, "Duoc thiet ke co nhieu lo thoang khi, phu hop voi nguoi choi the thao va di xe dap nen non co khoi luong sieu nhe. Chi khoang 265g.", "Non Xe Dap Zeus ST   ", "images/products/muxedap-zues2.png", 150m, 1, 1 },
                    { 3, "Vua ra mat giua nam nay (2022) nhung rat thu hut su quan tam cua khach hang. Day la mau non xe dap don gian, gon nhe.", "Non Xe Dap Yohe MD15 Trang", "images/products/muxedap-yohe2.png    ", 180m, 2, 1 },
                    { 4, "Thiet ke don gian, gon nhe, lo thong gio duoc thiet ke kieu dang khi dong hoc mang lai cam giac thong thoang.", "Non Xe Dap Yohe MH16 Xam to ong", "images/products/muxedap-yohe1.png", 300m, 2, 1 },
                    { 5, "Dung nhu ten goi no duoc thiet ke co luoi trai cach dieu bang vai phia truoc co the thao roi duoc. Form non gon nhe phu hop cho ca nguoi lon va tre em.", "Non Xe Dap Sunda F05 Hong Phan", "images/products/muxedap-sunda1.png    ", 250m, 4, 1 },
                    { 6, "Lop lot thoai mai va cam giu dang tot, khong gay ap luc len dau hoac mat, lop dem duoc che tao bang vat lieu Poly Source nen duoi ap suat cao.", "Non Xe Dap Royal R16", "images/products/muxedap-royal1.png    ", 120m, 5, 1 },
                    { 7, "Non fullface Yohe 981 voi 2 kinh chan duoc ra mat nham thay the model Yohe 970 da lam nen ten tuoi trong gioi Biker.", "Non FullFace Yohe", "images/products/fullface-yohe1.png", 10m, 2, 2 },
                    { 8, "Mu Fullface Sunda 811 co form non va chat luong tuong duong voi mu fullface Yohe 978 dang rat HOT hien nay nhung co gia thap nhieu.", "Non FullFace Sunda 811 Xanh Nham", "images/products/fullface-sunda1.png", 8m, 4, 2 },
                    { 9, "Mu bao hiem Fullface 2 kinh Sunda 823 duoc cau thanh tu chat lieu ABS nguyen sinh, cho do ben bi, dan hoi cao, chong chiu luc tac dong cuc tot . ", "Non FullFace Sunda 823 Xam Nham", "images/products/fullface-sunda2.png", 15m, 4, 2 },
                    { 10, " Se dac biet phu hop voi nhung ai yeu thich su gon gang, linh dong. Co the su dung trong tap Gym hoac choi cac mon the thao.", "Gang tay TORC Vang", "images/products/glove-torc1.png", 18m, 3, 4 },
                    { 11, "Được làm từ da lộn kết hợp vải cotton cao cấp. Có miếng đệm dưới lòng bàn tay tạo ma sát giúp cầm nắm dễ dàng hơn.", "Găng tay TORC Xanh", "images/products/glove-torc2.png", 15m, 3, 4 },
                    { 12, "la gang tay dai ngon duoc lam chu yeu tu da, co gu duoc lam tu chat lieu Titanium.", "Gang tay Sunda Trang", "images/products/glove-sunda1.png", 16m, 4, 4 },
                    { 13, "Polyester thoang mat va lop thun co gian ho tro thoang khi rat tot. Cac gu cao su ban tay va dot ngon tay duoc may an ben trong lop vai khien SUOMY SU-09 nhin rat bat mat.", "Gang tay Sunda Cam", "images/products/glove-sunda2.png", 14m, 4, 4 },
                    { 14, "duoc cau thanh tu nhua ABS nguyen sinh, chat lieu giup non co trong luong nhe nhung dong thoi mang lai su cung cap, kha nang hap thu xung dong va phan tan luc khi co tac dong manh.", "Non Ba Phan Tu ROC Trang", "images/products/baphantu-roc1.png", 250m, 6, 3 },
                    { 15, "Vo non Yohe 852 Den Bong duoc lam tu nhua ABS nguyen sinh cao cap, co do dan hoi va chong chiu va dap tot. La loai nhua chuyen dung trong san xuat Mu bao hiem, thiet bi y te…", "Non Ba Phan Tu YoHe Den", "images/products/baphantu-yohe1.png", 189.99m, 2, 3 },
                    { 16, "Duoc lam tu nhua ABS nguyen sinh cao cap, co do dan hoi va chong chiu va dap tot. La loai nhua chuyen dung trong san xuat Mu bao hiem, thiet bi y te…", "Non Ba Phan Tu YoHe Xam", "images/products/baphantu-yohe2.png", 199.99m, 2, 3 },
                    { 17, "Non Zues duoc tao ra voi su sang tao va dot pha tu cong nghe in 3D co do ben cao voi nhua cao cap", "Non Ba Phan Tu Zues Trang", "images/products/baphantu-zues2.png", 150m, 1, 3 },
                    { 18, "Non Zues duoc tao ra voi su sang tao va dot pha tu cong nghe in 3D co do ben cao voi nhua cao cap", "Non Ba Phan Tu Zues Xam", "images/products/baphantu-zues1.png", 180m, 1, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
