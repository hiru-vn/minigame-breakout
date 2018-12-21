# minigame-breakout
I. Giới thiệu
	Các lớp gạch được xếp phía nửa trên màn hình. Một quả bóng di chuyển trong phạm vi màn hình và bị nảy bật lại khi chạm vào góc trên và hai bên. Khi một viên gạch bị bắn trúng bởi quả bóng thì quả bóng nảy ra và viên gạch bị nứt hoặc bị phá hủy. Người chơi điều khiển một ván trượt phía dưới màn hình để không cho quả bóng chạm đáy màn hình. Người chơi sẽ chiến thắng khi phá hủy toàn bộ gạch và sẽ mất một lượt chơi. Khi hết lượt chơi mà vẫn chưa phá hết gạch thì sẽ thua cuộc.
  Nhóm gồm hai thành viên: Nguyễn Quang Huy – 17520583, Phạm Phúc Khải – 17520081. Xây dựng và thiết kế game giống thể loại game Breakout tuy nhiên được nâng cấp và được thêm nhiều tính năng. Dự án được làm qua phần mềm quản lí Source Code GitHub. Link đồ án: https://github.com/huynguyen1999kh/minigame-breakout
II. Thiết kế
	Game được thiết kế phân lớp rõ ràng tương ứng với từng đối tượng. Nhiều tính năng hấp dẫn cùng với âm thanh sinh động.
2.1/ Giới thiệu
	Game được mã hóa với mật khẩu là số chẵn và tự động nhớ mật khẩu sau lần đầu đăng nhập. Sau khi đăng nhập là phần màn hình chính của trò chơi với 4 lựa chọn: 
+ Single Player: Tương ứng với người chơi đơn, cổ điển thông thường.
+ Two Player: Hai người chơi, chơi cùng với nhau.
+ Vs Computer: Người chơi sẽ chiến đấu với máy. Có ba chế độ để lựa chọn là dễ, trung bình và khó để người chơi có thể lựa chọn.
+ Quit Game: Thoát game.
2.2/ Hướng dẫn chơi game
	- Chế độ Single Player: 
Dùng phím A, D hoặc →  ←  hoặc chuột để di chuyển ván trượt sang trái hoặc sang phải, nhấn Enter hoặc chuột trái để banh di chuyển (nảy) nhanh hơn. Phía trên có Score thể hiện điểm số, và trái tim thể hiện số lượt chơi (mạng) tương ứng của người chơi. Góc trái trên màn hình là nút Pause để tạm dừng trò chơi hoặc trở về màn hình chính. Trò chơi sẽ tự động dừng lại khi lost focus để bạn không bị quấy rầy giữa chừng.
 
Bạn sẽ thua cuộc khi để số mạng giảm xuống 0, hoặc khi hết thời gian. Chú ý nhặt các vật phẩm rơi ra để dễ dàng chiến thắng cho trò chơi. Các vật phẩm như: Tăng kích thước ván, súng bắn gạch, tăng tốc độ, thêm mạng. Tuy nhiên vẫn có một vài vật phẩm có hại làm thu nhỏ, làm chậm ván của bạn nên hãy cẩn thận.
-	Chế độ Two Player: 
Hai người chơi, một dùng chuột, một dùng bàn phím A, D hoặc →  ←  để di chuyển, chú ý các vật thể cản bóng có thể làm bạn mất lược chơi một cách bất ngờ. Người chơi nào hết lượt chơi trước sẽ thua cuộc và người còn lại là người chiến thắng.
 
-	Chế độ Vs Computer: 
     
Bao gồm 3 chế độ chơi từ dễ đến khó. Dùng chuột hoặc bàn phím với hai phím A, D để di chuyển. Vật cản y như trong chế độ hai người chơi tuy nhiên ở đây bạn phải chiến đấu với mấy với độ thông minh theo từng cấp độ. Hình thức chơi cũng vậy, ai hết lượt chơi trước sẽ thua.
III/ Kết luận và hướng phát triển
	Game còn khá đơn giản, với đồ họa còn khá đơn sơ. Tính chính xác trong việc xử lí va chạm đôi khi còn phát sinh lỗi. 
	Đó là những lí do mà đề tài còn nhiều hướng để nâng cấp và phát triển. Cũng như cải thiện, tối ưu code và tạo các chế độ các map mới hấp dẫn người chơi.
