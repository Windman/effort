﻿#region License

// Copyright (c) 2011 Effort Team
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is 
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common.CommandTrees;
using System.Linq.Expressions;

namespace Effort.DbCommandTreeTransform
{
    /// <summary>
    /// A visitor, that searches for tables in the DbExpressionTree
    /// </summary>
    internal class TableScanVisitor : DbExpressionVisitor<Expression>
    {
        public List<string> Tables { get; set; }

        public TableScanVisitor()
        {
            this.Tables = new List<string>();
        }

        public override Expression Visit( DbVariableReferenceExpression expression )
        {
            return null;
        }

        public override Expression Visit( DbUnionAllExpression expression )
        {
            this.Visit( expression.Left );
            this.Visit( expression.Right );
            return null;
        }

        public override Expression Visit( DbTreatExpression expression )
        {
            this.Visit( expression.Argument );
            return null;
        }

        public override Expression Visit( DbSkipExpression expression )
        {
            this.Visit( expression.Input.Expression );
            return null;
        }

        public override Expression Visit( DbSortExpression expression )
        {
            this.Visit( expression.Input.Expression );
            return null;
        }

        public override Expression Visit( DbScanExpression expression )
        {
            this.Tables.Add( expression.Target.Name );
            return null;
        }

        public override Expression Visit( DbRelationshipNavigationExpression expression )
        {
            this.Visit( expression.NavigationSource );
            return null;
        }

        public override Expression Visit( DbRefExpression expression )
        {
            this.Visit( expression.Argument );
            return null;
        }

        public override Expression Visit( DbQuantifierExpression expression )
        {
            this.Visit( expression.Input.Expression );
            this.Visit( expression.Predicate );
            return null;
        }

        public override Expression Visit( DbPropertyExpression expression )
        {
            this.Visit( expression.Instance );
            return null;
        }

        public override Expression Visit( DbProjectExpression expression )
        {
            this.Visit( expression.Input.Expression );
            this.Visit( expression.Projection );
            return null;
        }

        public override Expression Visit( DbParameterReferenceExpression expression )
        {
            return null;
        }

        public override Expression Visit( DbOrExpression expression )
        {
            this.Visit( expression.Left );
            this.Visit( expression.Right );
            return null;
        }

        public override Expression Visit( DbOfTypeExpression expression )
        {
            this.Visit( expression.Argument );
            return null;
        }

        public override Expression Visit( DbNullExpression expression )
        {
            return null;
        }

        public override Expression Visit( DbNotExpression expression )
        {
            this.Visit( expression.Argument );
            return null;
        }

        public override Expression Visit( DbNewInstanceExpression expression )
        {
            foreach( var arg in expression.Arguments )
                this.Visit( arg );
            return null;
        }

        public override Expression Visit( DbLimitExpression expression )
        {
            this.Visit( expression.Argument );
            this.Visit( expression.Limit );
            return null;
        }

        public override Expression Visit( DbLikeExpression expression )
        {
            this.Visit( expression.Argument );
            this.Visit( expression.Pattern );
            return null;
        }

        public override Expression Visit( DbJoinExpression expression )
        {
            this.Visit( expression.Left.Expression );
            this.Visit( expression.Right.Expression );
            return null;
        }

        public override Expression Visit( DbIsOfExpression expression )
        {
            this.Visit( expression.Argument );
            return null;
        }

        public override Expression Visit( DbIsNullExpression expression )
        {
            this.Visit( expression.Argument );
            return null;
        }

        public override Expression Visit( DbIsEmptyExpression expression )
        {
            this.Visit( expression.Argument );
            return null;
        }

        public override Expression Visit( DbIntersectExpression expression )
        {
            this.Visit( expression.Left );
            this.Visit( expression.Right );
            return null;
        }

        public override Expression Visit( DbGroupByExpression expression )
        {
            this.Visit( expression.Input.Expression );
            foreach( var arg in expression.Keys )
                this.Visit( arg );
            return null;
        }

        public override Expression Visit( DbRefKeyExpression expression )
        {
            this.Visit( expression.Argument );
            return null;
        }

        public override Expression Visit( DbEntityRefExpression expression )
        {
            this.Visit( expression.Argument );
            return null;
        }

        public override Expression Visit( DbFunctionExpression expression )
        {
            foreach( var arg in expression.Arguments )
                this.Visit( arg );
            return null;
        }

        public override Expression Visit( DbFilterExpression expression )
        {
            this.Visit( expression.Input.Expression );
            return null;
        }

        public override Expression Visit( DbExceptExpression expression )
        {
            this.Visit( expression.Left );
            this.Visit( expression.Right );
            return null;
        }

        public override Expression Visit( DbElementExpression expression )
        {
            this.Visit( expression.Argument );
            return null;
        }

        public override Expression Visit( DbDistinctExpression expression )
        {
            this.Visit( expression.Argument );
            return null;
        }

        public override Expression Visit( DbDerefExpression expression )
        {
            this.Visit( expression.Argument );
            return null;
        }

        public override Expression Visit( DbCrossJoinExpression expression )
        {
            foreach( var arg in expression.Inputs )
                this.Visit( arg.Expression );
            return null;
        }

        public override Expression Visit( DbConstantExpression expression )
        {
            return null;
        }

        public override Expression Visit( DbComparisonExpression expression )
        {
            this.Visit( expression.Left );
            this.Visit( expression.Right );
            return null;
        }

        public override Expression Visit( DbCastExpression expression )
        {
            this.Visit( expression.Argument );
            return null;
        }

        public override Expression Visit( DbCaseExpression expression )
        {
            foreach( var arg in expression.When )
                this.Visit( arg );
            this.Visit( expression.Else );
            foreach( var arg in expression.Then )
                this.Visit( arg );

            return null;
        }

        public override Expression Visit( DbArithmeticExpression expression )
        {
            foreach( var arg in expression.Arguments )
                this.Visit( arg );
            return null;
        }

        public override Expression Visit( DbApplyExpression expression )
        {
            this.Visit( expression.Input.Expression );
            this.Visit( expression.Apply.Expression );
            return null;
        }

        public override Expression Visit( DbAndExpression expression )
        {
            this.Visit( expression.Left );
            this.Visit( expression.Right );
            return null;
        }

        public override Expression Visit( DbExpression expression )
        {
            return expression.Accept( this );
        }
    }
}