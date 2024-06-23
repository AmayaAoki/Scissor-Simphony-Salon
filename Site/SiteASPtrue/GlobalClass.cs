using SiteASP.Models;


namespace SiteASP
{
    public static class GlobalClass
    {
        // пользователь
        public static bool IsAutorized { get; set; } = false;
        public static string? SessionValue { get; set; }
        public static int UserId { get; set; }
        public static string? Login { get; set; }
        public static string? Password { get; set; }
        public static string? FIO { get; set; }
        public static string? Email { get; set; }
        public static string? PhoneNumber { get; set; }
        public static string? Photo { get; set; }

        //какая запись
        public static int AppointmentId;
        public static string? EmployeeId;
        public static string? ServiceId;
        public static DateTime Date;
        public static TimeSpan EventTime;
        public static string? Status;

        //сервис
        public static string ServiceName { get; set; } = "Женская стрижка короткая";
        public static string EmployeeName { get; set; } = "Пересторонин Антон Адамович";
        public static string? AppDate { get; set; }

    }
}
