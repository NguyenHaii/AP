// Sử dụng database
use truonghoc

// Xóa collection cũ nếu có
db.hocsinh.drop()

// Thêm học sinh với năm sinh và danh sách môn học
db.hocsinh.insertMany([
  {
    ten: "An",
    namSinh: 2006,
    lop: "12A1",
    monHoc: [
      { tenMon: "Toán", diem: 9.0, giaoVien: "Thầy Tùng" },
      { tenMon: "Văn", diem: 7.5, giaoVien: "Cô Hương" },
      { tenMon: "Anh", diem: 8.0, giaoVien: "Cô Lan" }
    ]
  },
  {
    ten: "Bình",
    namSinh: 2007,
    lop: "11A2",
    monHoc: [
      { tenMon: "Toán", diem: 6.5, giaoVien: "Thầy Tùng" },
      { tenMon: "Lý", diem: 7.0, giaoVien: "Thầy Minh" }
    ]
  },
  {
    ten: "Chi",
    namSinh: 2006,
    lop: "12A1",
    monHoc: [
      { tenMon: "Toán", diem: 9.5, giaoVien: "Thầy Tùng" },
      { tenMon: "Văn", diem: 9.1, giaoVien: "Cô Hương" },
      { tenMon: "Anh", diem: 8.3, giaoVien: "Cô Lan" }
    ]
  },
  {
    ten: "Dung",
    namSinh: 2008,
    lop: "10A1",
    monHoc: [
      { tenMon: "Toán", diem: 7.0, giaoVien: "Thầy Tùng" },
      { tenMon: "Hóa", diem: 6.5, giaoVien: "Thầy Bảo" }
    ]
  },
  {
    ten: "Hà",
    namSinh: 2007,
    lop: "11A1",
    monHoc: [
      { tenMon: "Toán", diem: 10.0, giaoVien: "Thầy Tùng" },
      { tenMon: "Anh", diem: 9.5, giaoVien: "Cô Lan" }
    ]
  }
])

// ===== TRUY VẤN CƠ BẢN =====

// 1. Tìm học sinh lớp 12A1
db.hocsinh.find({ lop: "12A1" })

// 2. Tìm học sinh có học môn Văn
db.hocsinh.find({ "monHoc.tenMon": "Văn" })

// 3. Tìm học sinh có điểm Toán > 8
db.hocsinh.find({
  monHoc: { $elemMatch: { tenMon: "Toán", diem: { $gt: 8 } } }
})

// 4. Cập nhật điểm Lý của "Bình" thành 8.5
db.hocsinh.updateOne(
  { ten: "Bình", "monHoc.tenMon": "Lý" },
  { $set: { "monHoc.$.diem": 8.5 } }
)

// 5. Thêm môn Hóa cho "An"
db.hocsinh.updateOne(
  { ten: "An" },
  {
    $push: {
      monHoc: { tenMon: "Hóa", diem: 7.8, giaoVien: "Thầy Bảo" }
    }
  }
)

// 6. Xóa học sinh có môn nào điểm < 6
db.hocsinh.deleteMany({
  monHoc: { $elemMatch: { diem: { $lt: 6 } } }
})

// ===== THỐNG KÊ VÀ PHÂN TÍCH =====

// 7. Đếm số học sinh mỗi lớp
db.hocsinh.aggregate([
  { $group: { _id: "$lop", soLuong: { $sum: 1 } } }
])

// 8. Tính điểm trung bình các môn của mỗi học sinh
db.hocsinh.aggregate([
  {
    $project: {
      ten: 1,
      lop: 1,
      diemTrungBinh: { $avg: "$monHoc.diem" }
    }
  }
])

// 9. Sắp xếp học sinh theo năm sinh tăng dần (tức tuổi giảm dần)
db.hocsinh.find().sort({ namSinh: 1 })

// 10. Tìm 2 học sinh có điểm Toán cao nhất
db.hocsinh.aggregate([
  { $match: { "monHoc.tenMon": "Toán" } },
  {
    $project: {
      ten: 1,
      diemToan: {
        $first: {
          $filter: {
            input: "$monHoc",
            as: "mh",
            cond: { $eq: ["$$mh.tenMon", "Toán"] }
          }
        }
      }
    }
  },
  { $sort: { "diemToan.diem": -1 } },
  { $limit: 2 }
])

// ===== TÍNH TUỔI VÀ TRUY VẤN THEO TUỔI =====

// 11. Thêm cột tuổi và lọc học sinh có tuổi > 20
// (Giả sử năm hiện tại là 2025)
db.hocsinh.aggregate([
  {
    $addFields: {
      tuoi: { $subtract: [2025, "$namSinh"] }
    }
  },
  {
    $match: {
      tuoi: { $gt: 20 }
    }
  },
  {
    $project: {
      ten: 1,
      lop: 1,
      namSinh: 1,
      tuoi: 1
    }
  }
])
