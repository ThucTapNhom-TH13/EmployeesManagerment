create proc Xem_nhan_vien
as
begin
select maNV as N'Mã nhân viên', tenNV as N'Tên nhân viên',
 ngaySinh as N'Ngày sinh', gioiTinh as N'Giới tính',
 sdt as N'Sđt', diaChi as N'Địa chỉ', luong as N'Lương',
 nguoiGiamSat as N'Mã người giám sát', maPB as N'Mã phòng ban'
from NhanVien
end

go

create proc Sua_nhan_vien (@id int, @ten nvarchar(100), @ngaysinh date, @gt bit, @sdt nvarchar(100), @diachi nvarchar(100),
@luong money, @nguoiGiamSat int, @maPB int)
as
begin
update NhanVien
set tenNV = @ten, ngaySinh = @ngaysinh, gioiTinh = @gt, sdt = @sdt,
diaChi = @diachi, luong = @luong, nguoiGiamSat = @nguoiGiamSat, maPB = @maPB
where maNV = @id
end

go

create proc Them_nhan_vien (@ten nvarchar(100), @ngaysinh date, @gt bit, @sdt nvarchar(100), @diachi nvarchar(100),
@luong money, @nguoiGiamSat int, @maPB int)
as
begin
insert into NhanVien
values (@ten, @ngaysinh, @gt, @sdt, @diachi,
@luong, @nguoiGiamSat, @maPB)
end

select * from ThamGia

create proc Xem_du_an_tham_gia (@id int)
as
begin
select ThamGia.maDA as N'Mã dự án', tenDA as N'Tên dự án',  soGioLam as N'Số giờ làm', nhiemVu as N'Nhiệm vụ'
from ThamGia left join DuAn
on ThamGia.maDA = DuAn.maDA
where ThamGia.maNV = @id
end

go

create proc Xoa_nhan_vien (@id int)
as
begin
delete from NhanVien
where maNV = @id
end

create proc nghiLam_insert (@manv int, @lydo nvarchar(100), @ngaynghi date, @cophep bit, @khongluong bit) as 
begin
	insert into NghiLam(maNV, lyDo, ngayNghi, coPhep, nghiKhongLuong)
	values (@manv, @lydo, @ngaynghi, @cophep, @khongluong)
end

create proc nghiLam_update (@manv int, @lydo nvarchar(100), @ngaynghi date, @cophep bit, @khongluong bit, @ma int) as 
begin
	update NghiLam
	set maNV = @manv, lyDo = @lydo, ngayNghi = @ngaynghi, coPhep = @cophep, nghiKhongLuong = @khongluong
	where maNghi = @ma
end

create proc nghiLam_delete (@ma int) as begin
	delete from NghiLam where maNghi = @ma
end