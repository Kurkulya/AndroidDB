using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.RecyclerView;
using Android.Support.V7.Widget;
using Android.Graphics;

namespace AndroidDB.Droid.RV
{
    public class PersonDBAdapter : RecyclerView.Adapter
    {
        List<Person> people;

        public PersonDBAdapter(List<Person> people)
        {
            this.people = people;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // set the view's size, margins, paddings and layout parameters
            var id = Resource.Layout.Item;
            var itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            return new PersonViewHolder(itemView);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            Person person = people.ElementAt(position);

            var holder = viewHolder as PersonViewHolder;
            holder.Id.Text = person.Id.ToString();
            holder.FirstName.Text = person.FirstName;
            holder.LastName.Text = person.LastName;
            holder.Age.Text = person.Age.ToString();
        }

        public override int ItemCount
        {
            get { return people.Count; }
        }
    }
}