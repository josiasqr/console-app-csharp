class Request
{
    private string id;
    private string order;
    private string applicant;
    private string failure;
    private string description;
    private double cost;
    private static string HEADER_REGEX = "{0,-40} {1,-10} {2,-20} {3,-40} {4,-40} {5,-10}";

    public Request()
    {
    }

    // Genera un UUID
    public string generateId()
    {
        return Guid.NewGuid().ToString();
    }

    // Header que se registra en el archivo
    public static string headerInFIle()
    {
        return "ID" + "," + "ORDER" + "," + "APPLICANT" + "," + "FAILURE" + "," + "DESCRIPTION" + "," + "COST";
    }

    // Datos que se registra en el arhivo
    public string dataInFIle()
    {
        return this.id + "," + this.order + "," + this.applicant + "," + this.failure + "," + this.description + "," + this.cost;
    }

    // Header que se muestra en pantalla
    public static string printHeader()
    {
        return "--------------------------------------------------------------------------------"
                + "--------------------------------------------------------------------------------"
                + "\n"
                + String.Format(HEADER_REGEX, "ID", "ORDER", "APPLICANT", "FAILURE", "DESCRIPTION", "COST")
                + "\n"
                + "--------------------------------------------------------------------------------"
                + "--------------------------------------------------------------------------------";
    }

    // Datos que se muestra en pantalla
    public override string ToString()
    {
        return String.Format(HEADER_REGEX, this.id, this.order, this.applicant, this.failure, this.description, this.cost);
    }

    public string Id { get => id; set => id = value; }
    public string Order { get => order; set => order = value; }
    public string Applicant { get => applicant; set => applicant = value; }
    public string Failure { get => failure; set => failure = value; }
    public string Description { get => description; set => description = value; }
    public double Cost { get => cost; set => cost = value; }
}