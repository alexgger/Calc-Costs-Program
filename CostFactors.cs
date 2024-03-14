namespace CalculationСostsProgram
{
    class CostFactors
    {
        // Требуемая надежность ПО (Required Software Reliability)
        public static readonly double[] RELY =
        {
            0.75, 0.88, 1, 1.15, 1.39, 1.39
        };

        // Размер базы данных (Data Base Size)
        public static readonly double[] DATA =
        {
            0.93, 0.93, 1, 1.09, 1.19, 1.19
        };

        // Сложность продукта (Product Complexity)
        public static readonly double[] CPLX =
        {
            0.75, 0.88, 1, 1.14, 1.29, 1.49
        };

        // Требуемая повторная используемость (Required Reusability)
        public static readonly double[] RUSE =
        {
            0.91, 0.91, 1.0, 1.14, 1.29, 1.49
        };

        // Документирование требований жизненного цикла (Documentation match to life-cycle needs)
        public static readonly double[] DOCU =
        {
            0.89, 0.95, 1.0, 1.06, 1.13, 1.13
        };

        // Ограничения времени выполнения (Execution Time Constraint)
        public static readonly double[] TIME =
        {
            1, 1, 1, 1.11, 1.31, 1.67
        };

        // Ограничения оперативной памяти (Main Storage Constraint)
        public static readonly double[] STOR =
        {
            1, 1, 1, 1.06, 1.21, 1.57,
        };

        // Изменчивость платформы (Platform Volatility)
        public static readonly double[] PVOL =
        {
            0.87, 0.87, 1.0, 1.15, 1.3, 1.3
        };

        // Возможности аналитика (Analyst Capability)
        public static readonly double[] ACAP =
        {
            1.5, 1.22, 1.0, 0.83, 0.67, 0.67
        };

        // Возможности программиста (Programmer Capability)
        public static readonly double[] PCAP =
        {
            1.37, 1.16, 1.0, 0.87, 0.74, 0.74
        };

        // Непрерывность персонала (Personnel Continuity)
        public static readonly double[] PCON =
        {
            1.24, 1.1, 1.0, 0.92, 0.84, 0.84
        };

        // Опыт работы с приложением (Applications Experience)
        public static readonly double[] AEXP =
        {
            1.22, 1.1, 1.0, 0.89, 0.81, 0.81
        };

        // Опыт работы с платформой (Platform Experience)
        public static readonly double[] PEXP =
        {
            1.25, 1.12, 1.0, 0.88, 0.81, 0.81
        };

        // Опыт работы с языком и утилитами (Language and Tool Experience) 
        public static readonly double[] LTEX =
        {
            1.22, 1.1, 1.0, 0.91, 0.84, 0.84
        };

        // Использование программных утилит (Use of Software Tools)
        public static readonly double[] TOOL =
        {
            1.24, 1.12, 1.0, 0.86, 0.72, 0.72
        };

        // Мультисетевая разработка (Multisite Development)
        public static readonly double[] SITE =
        {
            1.25, 1.1, 1.0, 0.92, 0.84, 0.78
        };

        // Требуемый график разработки (Required Development Schedule)
        public static readonly double[] SCED =
        {
            1.29, 1.1, 1.0, 1.0, 1.0, 1.0
        };
    }
}
