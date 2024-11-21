using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using QLPhongMachTu_DOAN_.DTO;
using QLPhongMachTu_DOAN_.Enums;

namespace QLPhongMachTu_DOAN_.DAL
{
    public class HoaDonKhamBenhDAL : DatabaseHelper
    {
        private readonly string _connectionString;

        public HoaDonKhamBenhDAL()
        {
            // Lấy chuỗi kết nối từ app.config
            _connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        }

        public List<HoaDonKhamBenh> GetAllByMaBN(long MaBN)
        {
            List<HoaDonKhamBenh> listH = new List<HoaDonKhamBenh>();
            string query = @"SELECT *
                            FROM HoaDonKhamBenhs
                            WHERE MaBN = @MaSo";
            
            // Mo connection
            using (SqlConnection conection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, conection);
                command.Parameters.AddWithValue("@MaSo", MaBN);
                conection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HoaDonKhamBenh hd = new HoaDonKhamBenh();
                        hd.MaHDKB = Convert.ToInt64(reader[0]);
                        hd.MaBN = Convert.ToInt64(reader[1]);
                        hd.MaBS = Convert.ToInt64(reader[2]);
                        hd.MaPK = Convert.ToInt64(reader[3]);
                        hd.TongTien = Convert.ToDouble(reader[4]);
                        hd.TrangThai = (Enums.ETrangThaiHoaDon)Convert.ToInt32(reader[5]);
                        
                        listH.Add(hd);
                    }
                }
            }

            return listH;
        }

        public bool ThanhToanHoaDon(long maHDKB, int trangThaiHoaDon)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE HoaDonKhamBenhs
                                SET TrangThai = @TrangThai
                                WHERE MaHDKB = @MaHDKB";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TrangThai", maHDKB);
                command.Parameters.AddWithValue("@MaHDKB", trangThaiHoaDon);
                connection.Open();
                
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0; // Trả về true nếu cập nhật thành công
            }
        }

        public List<HoaDonKhamBenh> TimKiemByTongSoTien(double tongSoTien)
        {
            List<HoaDonKhamBenh> resultList = new List<HoaDonKhamBenh>();
            using (SqlConnection connection =new SqlConnection(_connectionString))
            {
                string query = @"SELECT *
                                FROM HoaDonKhamBenhs
                                WHERE TongTien = @TongTien";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TongTien", tongSoTien);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HoaDonKhamBenh hd = new HoaDonKhamBenh();
                        hd.MaHDKB = Convert.ToInt64(reader[0]);
                        hd.MaBN = Convert.ToInt64(reader[1]);
                        hd.MaBS = Convert.ToInt64(reader[2]);
                        hd.MaPK = Convert.ToInt64(reader[3]);
                        hd.TongTien = Convert.ToDouble(reader[4]);
                        hd.TrangThai = (Enums.ETrangThaiHoaDon)Convert.ToInt32(reader[5]);
                        
                        resultList.Add(hd);
                    }
                }

                return resultList;
            }
        }
        
        public List<HoaDonKhamBenh> TimKiemByTrangThai(int trangThai)
        {
            List<HoaDonKhamBenh> resultList = new List<HoaDonKhamBenh>();
            using (SqlConnection connection =new SqlConnection(_connectionString))
            {
                string query = @"SELECT *
                                FROM HoaDonKhamBenhs
                                WHERE TrangThai = @TrangThai";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TrangThai", trangThai);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HoaDonKhamBenh hd = new HoaDonKhamBenh();
                        hd.MaHDKB = Convert.ToInt64(reader[0]);
                        hd.MaBN = Convert.ToInt64(reader[1]);
                        hd.MaBS = Convert.ToInt64(reader[2]);
                        hd.MaPK = Convert.ToInt64(reader[3]);
                        hd.TongTien = Convert.ToDouble(reader[4]);
                        hd.TrangThai = (Enums.ETrangThaiHoaDon)Convert.ToInt32(reader[5]);
                        
                        resultList.Add(hd);
                    }
                }

                return resultList;
            }
        }
    }
}