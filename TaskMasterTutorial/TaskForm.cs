using TaskMasterTutorial.Model;

namespace TaskMasterTutorial
{
    public partial class TaskForm : Form
    {
        private tmDbContext tmContext;
        public TaskForm()
        {
            InitializeComponent();
            tmContext = new tmDbContext();

            var statuses = tmContext.Statuses.ToList();
            foreach (var stat in statuses)
            {
                cbStatus.Items.Add(stat);
            }
            cbStatus.SelectedItem = cbStatus.Items[0];

            RefreshData();
        }

        private void RefreshData()
        {
            BindingSource bd= new BindingSource();

            var query = from t in tmContext.Tasks
                        orderby t.Date
                        select new {t.Id, TaskName = t.Name, TaskStatus = t.Status.Name, t.Date};

            bd.DataSource = query.ToList();

            dataGridView1.DataSource = bd;
            dataGridView1.Refresh();
        }

        private void cmdCreateTask_Click(object sender, EventArgs e)
        {
            if (cbStatus.SelectedItem != null && txtTask.Text != String.Empty)
            {
                var newTask = new Model.Task
                {
                    Name = txtTask.Text,
                    StatusId = ((Model.Status)cbStatus.SelectedItem).Id,
                    Date = dateTask.Value
                };
                tmContext.Tasks.Add(newTask);
                tmContext.SaveChanges();
                RefreshData();
            }
            else
            {
                MessageBox.Show("Please, enter a task name","Error");
            }
        }

        private void cmdUpdateTask_Click(object sender, EventArgs e)
        {
            if (cmdUpdateTask.Text == "Update")
            {
                var test = dataGridView1;
                txtTask.Text = dataGridView1.SelectedCells[1].Value.ToString();
                dateTask.Value = (DateTime)dataGridView1.SelectedCells[3].Value;
                foreach (Status s in cbStatus.Items)
                {
                    if (s.Name == dataGridView1.SelectedCells[2].Value.ToString())
                    {
                        cbStatus.SelectedItem = s;
                    }
                }
                cmdUpdateTask.Text = "Save";
            }
            else if (cmdUpdateTask.Text == "Save")
            {
                var t = tmContext.Tasks.Find((int)dataGridView1.SelectedCells[0].Value);

                t.Name = txtTask.Text;
                t.StatusId = ((Model.Status)cbStatus.SelectedItem).Id;
                t.Date = dateTask.Value;

                tmContext.SaveChanges();
                RefreshData();
                cmdUpdateTask.Text = "Update";
                txtTask.Text = String.Empty;
                dateTask.Value = DateTime.Now;
                cbStatus.SelectedItem = cbStatus.Items[0];

            }
        }

        private void cmdDeleteTask_Click(object sender, EventArgs e)
        {
            var t = tmContext.Tasks.Find((int)dataGridView1.SelectedCells[0].Value);
            tmContext.Tasks.Remove(t);
            tmContext.SaveChanges();
            RefreshData();

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            cmdUpdateTask.Text = "Update";
            txtTask.Text = String.Empty;
            dateTask.Value = DateTime.Now;
            cbStatus.SelectedItem = cbStatus.Items[0];
        }
    }
}