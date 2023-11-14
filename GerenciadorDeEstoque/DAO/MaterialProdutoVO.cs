﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeEstoque.DAO
{
    class MaterialProdutoVO
    {

        private Int32 _itemid, idmaterial, idproduto;
        private DAO dao;
        private conexaoUso conn;

        MaterialProdutoVO()
        {

        }

        public Int32 itemid
        {
            get { return _itemid; }
            set { _itemid = value; }
        }
        public Int32 IdMaterial
        {
            get { return idmaterial; }
            set { idmaterial = value; }
        }
        public Int32 IdProduto
        {
            get { return idproduto; }
            set { idproduto = value; }
        }

        public void Inserir()
        {
            dao = new DAO();
            dao.IDMPRODUTO(IdMaterial, IdProduto);
        }

        public void Atualizar()
        {
            dao = new DAO();
            dao.ADMPRODUTO(IdMaterial, IdProduto, itemid);
        }
        public void Remover()
        {
            dao = new DAO();
            dao.RDMPRODUTO(IdMaterial, IdProduto, itemid);
        }

    }
}
